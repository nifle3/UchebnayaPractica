using System.Collections.ObjectModel;
using WpfApp1.Model;
using WpfApp1.ViewModel.Service;

namespace WpfApp1.ViewModel;

public sealed class SuggestionViewModel : BaseCrud<Suggestion>
{
    private readonly ISuggestionService _service;
    
    private Client _selectedClient = null!;
    private Estate _selectedEstate = null!;
    private Realtor _selectedRealtor = null!;
    private decimal _price;

    public SuggestionViewModel(ICrudService<Suggestion> crudService, ISuggestionService service) : base(crudService)
    {
        _service = service;

        Suggestions = _service.GetAll();
        Clients = _service.GetAllClients();
        Estates = _service.GetAllEstates();
        Realtors = _service.GetAllRealtors();
        
        AddEvent += Add;
        DeleteEvent += Delete;
    }

    public ObservableCollection<Suggestion> Suggestions { private set; get; }

    public List<Client> Clients { private set; get; }
    
    public List<Estate> Estates {private set; get; }
    
    public List<Realtor> Realtors { private set; get; }
    
    public Client SelectedClient
    {
        set => SetProperty(ref _selectedClient, value);
        get => _selectedClient;
    }

    public Estate SelectedEstate
    {
        set => SetProperty(ref _selectedEstate, value);
        get => _selectedEstate;
    }

    public Realtor SelectedRealtor
    {
        set => SetProperty(ref _selectedRealtor, value);
        get => _selectedRealtor;
    }

    public decimal Price
    {
        set => SetProperty(ref _price, value);
        get => _price;
    }

    protected override Suggestion GetEntity() =>
        new()
        {
            ClientNavigation = SelectedClient,
            EstateNavigation = SelectedEstate,
            Price = Price,
            RealtorNavigation = SelectedRealtor,
        };

    private void Add(Suggestion suggestion) =>
        Suggestions.Add(suggestion);

    private void Delete(Suggestion suggestion) =>
        Suggestions.Remove(suggestion);
}