using WpfApp1.ViewModel.Utils;

namespace WpfApp1.ViewModel.Need;

public sealed class HouseNeed : Need<HouseNeed>
{
    private double _minSquare = 0.0;
    private double _maxSquare = 0.0;
    private int _minRoomsCount = 0;
    private int _maxRoomsCount = 0;
    private int _minFloorsCount = 0;
    private int _maxFloorsCount = 0;
    
    public HouseNeed(IAlert alert) : base(alert)
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

    public int MinFloorsCount
    {
        set => SetField(ref _minFloorsCount, value);
        get => _minFloorsCount;
    }

    public int MaxFloorsCount
    {
        set => SetField(ref _maxFloorsCount, value);
        get => _maxFloorsCount;
    }

    protected override async Task Add()
    {
        var need = new Model.HouseNeed()
        {
            
        };

        try
        {
            await Context.HouseNeeds.AddAsync(need);
            await Context.SaveChangesAsync();

            Notifier.Alert(AddSuccessMessage);
        }
        catch
        {
            Notifier.Alert(DbErrorMessage);
        }
    }

    protected override async Task Delete(HouseNeed? entity)
    {
        throw new NotImplementedException();
    }

    protected override async Task Update(HouseNeed? entity)
    {
        throw new NotImplementedException();
    }
}