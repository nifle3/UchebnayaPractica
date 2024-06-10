using WpfApp1.Model;
using WpfApp1.ViewModel.Service;

namespace WpfApp1.ViewModel;

public sealed class ApartmentNeedViewModel : NeedViewModel<ApartmentsNeed>
{
    private const string EstateType = "apartment";
    
    private double _minSquare = 0.0;
    private double _maxSquare = 0.0;
    private int _minRoomsCount = 0;
    private int _maxRoomsCount = 0;
    private int _minFloor = 0;
    private int _maxFloor = 0;
    
    public ApartmentNeedViewModel(ICrudService<ApartmentsNeed> crudService) : base(crudService)
    {
    }

    public double MinSquare
    {
        set => SetProperty(ref _minSquare, value);
        get => _minSquare;
    }

    public double MaxSquare
    {
        set => SetProperty(ref _maxSquare, value);
        get => _maxSquare;
    }

    public int MinRoomsCount
    {
        set => SetProperty(ref _minRoomsCount, value);
        get => _minRoomsCount;
    }

    public int MaxRoomsCount
    {
        set => SetProperty(ref _maxRoomsCount, value);
        get => _maxRoomsCount;
    }

    public int MinFloor
    {
        set => SetProperty(ref _minFloor, value);
        get => _minFloor;
    }

    public int MaxFloor
    {
        set => SetProperty(ref _maxFloor, value);
        get => _maxFloor;
    }

    protected override ApartmentsNeed GetEntity() =>
        new ApartmentsNeed()
        {
            ClientNavigation = SelectedClient,
            RealtorNavigation = SelectedRealtor,
            EstateType = EstateType,
            MaxFloor = MaxFloor == 0 ? null : MaxFloor,
            MinFloor = MinFloor == 0 ? null : MinFloor,
            MaxSquare = MaxSquare == 0.0 ? null : MaxSquare,
            MinSquare = MinSquare == 0.0 ? null : MinSquare,
            MaxRoomsCount = MaxRoomsCount == 0 ? null : MaxRoomsCount,
            MinRoomsCount = MinRoomsCount == 0 ? null : MinRoomsCount,
        };

    
}