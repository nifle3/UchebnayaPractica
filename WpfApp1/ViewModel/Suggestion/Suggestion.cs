using System.Collections.ObjectModel;
using WpfApp1.ViewModel.Utils;

namespace WpfApp1.ViewModel.Suggestion;

public sealed class Suggestion : BaseCrud<Model.Suggestion>
{
    private Model.Client _selectedClient = null!;
    private Model.Estate _selectedEstate = null!;
    private Model.Realtor _selectedRealtor = null!;
    private int _price;
    
    public Suggestion(IAlert alert) : base(alert) =>
        (Suggestions, Clients, Estates, Realtors) 
            = (new ObservableCollection<Model.Suggestion>(Context.Suggestions), Context.Clients.ToList(), Context.Estates.ToList(), Context.Realtors.ToList());

    public ObservableCollection<Model.Suggestion> Suggestions { private set; get; }

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

    public int Price
    {
        set => SetField(ref _price, value);
        get => _price;
    }

    protected override Task Add()
    {
        throw new NotImplementedException();
    }

    protected override Task Delete(Model.Suggestion? entity)
    {
        throw new NotImplementedException();
    }

    protected override void Update()
    {
        throw new NotImplementedException();
    }
}