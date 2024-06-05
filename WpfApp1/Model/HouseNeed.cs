namespace WpfApp1.Model;

public sealed partial class HouseNeed : Need
{
    public int? MinSquare { get; set; }

    public int? MaxSquare { get; set; }

    public int? MinRoomsCount { get; set; }

    public int? MaxRoomsCount { get; set; }

    public int? MinFloorsCount { get; set; }

    public int? MaxFloorsCount { get; set; }
}
