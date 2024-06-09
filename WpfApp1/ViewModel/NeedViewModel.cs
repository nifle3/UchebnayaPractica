using WpfApp1.ViewModel.Service;

namespace WpfApp1.ViewModel;

// TODO: Address
public abstract class NeedViewModel<T> : BaseCrud<T>
{
    private Model.Client _selectedClient = null!;
    private Model.Realtor _selectedRealtor = null!;
    private decimal _minPrice;
    private decimal _maxPrice;

    protected NeedViewModel(ICrudService<T> crudService) : base(crudService)
    {
    }

    public List<Model.Client> Clients { protected set; get; } = null!;

    public List<Model.Realtor> Realtors { protected set; get; } = null!;

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