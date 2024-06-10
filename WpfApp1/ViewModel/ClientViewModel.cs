using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Messaging;
using WpfApp1.Model;
using WpfApp1.ViewModel.Message;
using WpfApp1.ViewModel.Service;

namespace WpfApp1.ViewModel;

public sealed class ClientViewModel : BaseSearch<Client>
{
    private readonly IClientService _service;
    
    private string _name = "";
    private string _lastName = "";
    private string _middleName = "";
    private string _phoneNumber = "";
    private string _email = "";
    
    private string _searchName = "";
    private string _searchMiddleName = "";
    private string _searchLastName = "";

    public ClientViewModel(IClientService service, ICrudService<Client> crudService) : base(crudService)
    {
        _service = service;

        CanUpdateEvent += CanUpdate;
        DeleteEvent += Delete;
        AddEvent += Add;

        Clients = _service.GetAll();
    }
    
    public string Name
    {
        set => SetField(ref _name, value);
        get => _name;
    }

    public string LastName
    {
        set => SetField(ref _lastName, value);
        get => _lastName;
    }

    public string MiddleName
    {
        set => SetField(ref _middleName, value);
        get => _middleName;
    }

    public string PhoneNumber
    {
        set => SetField(ref _phoneNumber, value);
        get => _phoneNumber;
    }

    public string Email
    {
        set => SetField(ref _email, value);
        get => _email;
    }

    public string SearchName
    {
        set => SetField(ref _searchName, value);
        get => _searchName;
    }

    public string SearchMiddleName
    {
        set => SetField(ref _searchMiddleName, value);
        get => _searchMiddleName;
    }

    public string SearchLastName
    {
        set => SetField(ref _searchLastName, value);
        get => _searchLastName;
    }

    public ObservableCollection<Client> Clients { private set; get; }

    protected override async Task Search()
    {
        var task = Task.Run(() =>
        {
            const int minLevenstein = 3;
            IQueryable<Client> query = _service.GetForSearch();


            if (!string.IsNullOrWhiteSpace(SearchName))
                query = query
                    .Where(q => q.FirstName != null &&
                                RealtorsStoreContext.LevenshteinDistance(q.FirstName, SearchName) <= minLevenstein);

            if (!string.IsNullOrWhiteSpace(SearchLastName))
                query = query
                    .Where(q => q.LastName != null &&
                                RealtorsStoreContext.LevenshteinDistance(q.LastName, SearchLastName) <= minLevenstein);

            if (!string.IsNullOrWhiteSpace(SearchMiddleName))
                query = query.Where(q =>
                    q.MiddleName != null && RealtorsStoreContext.LevenshteinDistance(q.MiddleName, SearchMiddleName) <=
                    minLevenstein);

            Clients = new ObservableCollection<Client>(query);
        });

        await task;
    }

    protected override Client GetEntity() =>
        new Client()
        {
            Email = Email,
            FirstName = Name,
            LastName = LastName,
            MiddleName = MiddleName,
            Phone = PhoneNumber,
        };

    private void Add(Client client) =>
        Clients.Add(client);
    
    private void Delete(Client client) =>
        Clients.Remove(client);

    private bool CanUpdate(Client client)
    {
        if (!string.IsNullOrEmpty(client.Phone) || !string.IsNullOrEmpty(client.Email)) return true;
        
        WeakReferenceMessenger.Default.Send(new AlertMessage("Телефон или почты должны быть заполнены", ErrorCaptionsMessage));
        return false;
    } 
}