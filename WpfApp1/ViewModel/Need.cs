using WpfApp1.ViewModel.Utils;

namespace WpfApp1.ViewModel;

// TODO: Address
public abstract class Need<T> : BaseCrud<T>
{
    private Model.Client _selectedClient = null!;
    private Model.Realtor _selectedRealtor = null!;
    private decimal _minPrice;
    private decimal _maxPrice;

    protected Need(IAlert alert) : base(alert)
    {
        Clients = Context.Clients.ToList();
        Realtors = Context.Realtors.ToList();
    }

    public List<Model.Client> Clients { private set; get; }
    
    public List<Model.Realtor> Realtors { private set; get; }
    
    public Model.Client SelectedClient
    {
        set => SetField(ref _selectedClient, value);
        get => _selectedClient;
    }

    public Model.Realtor SelectedRealtor
    {
        set => SetField(ref _selectedRealtor, value);
        get => _selectedRealtor;
    }

    public decimal MinPrice
    {
        set => SetField(ref _minPrice, value);
        get => _minPrice;
    }

    public decimal MaxPrice
    {
        set => SetField(ref _maxPrice, value);
        get => _maxPrice;
    }
}