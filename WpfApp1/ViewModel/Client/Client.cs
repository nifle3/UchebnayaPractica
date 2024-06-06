using System.Collections.ObjectModel;
using WpfApp1.ViewModel.Utils;

namespace WpfApp1.ViewModel.Client;

public sealed class Client : BaseCrud<Model.Client>
{
    private string _name = "";
    private string _lastName = "";
    private string _middleName = "";
    private string _phoneNumber = "";
    private string _email = "";
    
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
    
    public ObservableCollection<Model.Client> Clients { private set; get; }

    protected override async Task Delete(Model.Client? client)
    {
        if (client is null) return;
        
        try
        {
            Context.Clients.Remove(client);
            await Context.SaveChangesAsync();
            
            Clients.Remove(client);
        }
        catch
        {
            Alert.Alert(DbErrorMessage);
        }
    }

    protected override void Update()
    {
        throw new NotImplementedException();
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
            await Context.Clients.AddAsync(client);
            await Context.SaveChangesAsync();
        }
        catch
        {
            Alert.Alert(DbErrorMessage);
        }
    }
}