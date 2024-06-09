using System.Collections.ObjectModel;
using WpfApp1.Model;
using WpfApp1.ViewModel.Utils;

namespace WpfApp1.ViewModel;

public sealed class SuggestionViewModel : BaseCrud<Suggestion>
{
    private Model.Client _selectedClient = null!;
    private Model.Estate _selectedEstate = null!;
    private Model.Realtor _selectedRealtor = null!;
    private decimal _price;
    
    public SuggestionViewModel(IAlert alert, ICrudService<Suggestion> service) : base(alert) =>
        (Suggestions, Clients, Estates, Realtors) 
            = (new ObservableCollection<Suggestion>(Context.Suggestions), Context.Clients.ToList(), 
                Context.Estates.ToList(), Context.Realtors.ToList());

    public ObservableCollection<Suggestion> Suggestions { private set; get; }

    public List<Model.Client> Clients { private set; get; }
    
    public List<Model.Estate> Estates {private set; get; }
    
    public List<Model.Realtor> Realtors { private set; get; }
    
    public Model.Client SelectedClient
    {
        set => SetField(ref _selectedClient, value);
        get => _selectedClient;
    }

    public Model.Estate SelectedEstate
    {
        set => SetField(ref _selectedEstate, value);
        get => _selectedEstate;
    }

    public Model.Realtor SelectedRealtor
    {
        set => SetField(ref _selectedRealtor, value);
        get => _selectedRealtor;
    }

    public decimal Price
    {
        set => SetField(ref _price, value);
        get => _price;
    }

    protected override async Task Add()
    {
        var suggestion = new Suggestion()
        {
            ClientNavigation = SelectedClient,
            EstateNavigation = SelectedEstate,
            Price = Price,
            RealtorNavigation = SelectedRealtor,
        };
    }

    protected override async Task Delete(Model.Suggestion? entity)
    {
        if (entity is null) return;
    }

    protected override async Task Update(Model.Suggestion? entity)
    {
        if (entity is null) return;
    }
}