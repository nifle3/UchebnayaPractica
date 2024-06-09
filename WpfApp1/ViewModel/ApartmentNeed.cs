using WpfApp1.Model;
using WpfApp1.ViewModel.Utils;

namespace WpfApp1.ViewModel;

public sealed class ApartmentNeed : Need<ApartmentsNeed>
{
    private const string EstateType = "apartment";
    
    private double _minSquare = 0.0;
    private double _maxSquare = 0.0;
    private int _minRoomsCount = 0;
    private int _maxRoomsCount = 0;
    private int _minFloor = 0;
    private int _maxFloor = 0;
    
    public ApartmentNeed(IAlert alert) : base(alert)
    {
    }

    public double MinSquare
    {
        set => SetField(ref _minSquare, value);
        get => _minSquare;
    }

    public double MaxSquare
    {
        set => SetField(ref _maxSquare, value);
        get => _maxSquare;
    }

    public int MinRoomsCount
    {
        set => SetField(ref _minRoomsCount, value);
        get => _minRoomsCount;
    }

    public int MaxRoomsCount
    {
        set => SetField(ref _maxRoomsCount, value);
        get => _maxRoomsCount;
    }

    public int MinFloor
    {
        set => SetField(ref _minFloor, value);
        get => _minFloor;
    }

    public int MaxFloor
    {
        set => SetField(ref _maxFloor, value);
        get => _maxFloor;
    }

    protected override async Task Add()
    {
        var need = new Model.ApartmentsNeed()
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

        try
        {
            await Context.AddAsync(need);
            await Context.SaveChangesAsync();

            Notifier.Alert(AddSuccessMessage);
        }
        catch
        {
            Notifier.Alert(DbErrorMessage);
        }
    }

    protected override async Task Delete(Model.ApartmentsNeed? entity)
    {
        if (entity is null) return;
    }

    protected override async Task Update(Model.ApartmentsNeed? entity)
    {
        if (entity is null) return;
    }
}