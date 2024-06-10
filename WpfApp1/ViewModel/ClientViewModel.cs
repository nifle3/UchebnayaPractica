using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using CommunityToolkit.Mvvm.Messaging;
using WpfApp1.Model;
using WpfApp1.ViewModel.Message;
using WpfApp1.ViewModel.Service;

namespace WpfApp1.ViewModel;

public sealed class ClientViewModel : BaseSearch<Client>
{
    private readonly IClientService _service;

    private Client? _selectedClient;
    
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

        CanModifyEvent += CanModify;
        DeleteEvent += Delete;
        AddEvent += Add;

        Clients = _service.GetAll();
    }

    public Client? SelectedClient
    {
        set => SetProperty(ref _selectedClient, value);
        get => _selectedClient;
    }
    
    public string Name
    {
        set => SetProperty(ref _name, value);
        get => _name;
    }

    public string LastName
    {
        set => SetProperty(ref _lastName, value);
        get => _lastName;
    }

    public string MiddleName
    {
        set => SetProperty(ref _middleName, value);
        get => _middleName;
    }

    public string PhoneNumber
    {
        set => SetProperty(ref _phoneNumber, value);
        get => _phoneNumber;
    }
    
    public string Email
    {
        set => SetProperty(ref _email, value);
        get => _email;
    }

    public string SearchName
    {
        set => SetProperty(ref _searchName, value);
        get => _searchName;
    }

    public string SearchMiddleName
    {
        set => SetProperty(ref _searchMiddleName, value);
        get => _searchMiddleName;
    }

    public string SearchLastName
    {
        set => SetProperty(ref _searchLastName, value);
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

            //Clients = new ObservableCollection<Client>(query);
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

    private static bool CanModify(Client client)
    {
        var emptyPhone = string.IsNullOrEmpty(client.Phone);
        var emptyEmail = string.IsNullOrEmpty(client.Email); 
        
        if (emptyEmail && emptyPhone)
        {
            WeakReferenceMessenger.Default.Send(new AlertMessage("Телефон или почты должны быть заполнены", ErrorCaptionsMessage));
            return true;
        }

        var validEmail = Regex.IsMatch(client.Email ?? "", "^\\S+@\\S+\\.\\S+$");
        var validPhone = Regex.IsMatch(client.Phone ?? "", "^\\+?[1-9][0-9]{7,14}$");

        if (!validEmail && emptyPhone)
        {
            WeakReferenceMessenger.Default.Send(new AlertMessage("Вы ввели не почту", ErrorCaptionsMessage));
            return false;
        }

        if (!validPhone && emptyEmail)
        {
            WeakReferenceMessenger.Default.Send(new AlertMessage("Вы ввели не телефон", ErrorCaptionsMessage));
            return false;
        }

        if (!validPhone && !validEmail)
        {
            WeakReferenceMessenger.Default.Send(new AlertMessage("Вы ввели не телефон и не почту",  ErrorCaptionsMessage));
        }
        
        
        return true;
    } 
}