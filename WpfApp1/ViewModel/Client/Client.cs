using System.Collections.ObjectModel;
using WpfApp1.Model;
using WpfApp1.ViewModel.Utils;

namespace WpfApp1.ViewModel.Client;

public sealed class Client : BaseSearch<Model.Client>
{
    private string _name = "";
    private string _lastName = "";
    private string _middleName = "";
    private string _phoneNumber = "";
    private string _email = "";
    private string _searchName = "";
    private string _searchMiddleName = "";
    private string _searchLastName = "";

    public Client(IAlert alert) : base(alert) =>
        Clients = new ObservableCollection<Model.Client>(Context.Clients);

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

    public ObservableCollection<Model.Client> Clients { private set; get; }

    protected override async Task Delete(Model.Client? client)
    {
        if (client is null) return;
        
        try
        {
            Context.Clients.Remove(client);
            await Context.SaveChangesAsync();
            
            Clients.Remove(client);
            Notifier.Alert(DeleteSuccessMessage);
        }
        catch
        {
            Notifier.Alert(DbErrorMessage);
        }
    }

    protected override async Task Update(Model.Client? entity)
    {
        if (entity is null) return;

        if (string.IsNullOrWhiteSpace(entity.Email) && string.IsNullOrWhiteSpace(entity.Phone))
        {
            Notifier.Alert("Телефон или почта должны быть заполнены");
            return;
        }

        try
        {
            Context.Clients.Update(entity);
            await Context.SaveChangesAsync();
            
            Notifier.Alert(UpdateSuccessMessage);
        }
        catch
        {
            Notifier.Alert(DbErrorMessage);
        }
    }

    protected override async Task Search()
    {
        var task = Task.Run(() =>
        {
            const int minLevenstein = 3;
            IQueryable<Model.Client> query = Context.Clients;
        

            if (!string.IsNullOrWhiteSpace(SearchName))
                query = query
                    .Where(q => q.FirstName != null && RealtorsStoreContext.LevenshteinDistance(q.FirstName, SearchName) <= minLevenstein);

            if (!string.IsNullOrWhiteSpace(SearchLastName))
                query = query
                    .Where(q => q.LastName != null && RealtorsStoreContext.LevenshteinDistance(q.LastName, SearchLastName) <= minLevenstein);

            if (!string.IsNullOrWhiteSpace(SearchMiddleName))
                query = query.Where(q =>
                    q.MiddleName != null && RealtorsStoreContext.LevenshteinDistance(q.MiddleName, SearchMiddleName) <=
                    minLevenstein);
        
            Clients = new ObservableCollection<Model.Client>(query);
        });
        
        await task;
    }

    protected override async Task Add()
    {
        var client = new Model.Client()
        {
            Email = Email,
            FirstName = Name,
            LastName = LastName,
            MiddleName = MiddleName,
            Phone = PhoneNumber,
        };
        
        try
        {
            var insertedClient = await Context.Clients.AddAsync(client);
            await Context.SaveChangesAsync();

            if (insertedClient.IsKeySet)
                Clients.Add(insertedClient.Entity);
            else
                Clients = new ObservableCollection<Model.Client>(Context.Clients);
            
            Notifier.Alert(AddSuccessMessage);
        }
        catch
        {
            Notifier.Alert(DbErrorMessage);
        }
    }
}