namespace WpfApp1.Model;

public sealed partial class ApartmentsNeed : Need
{
    public double? MinSquare { get; set; }

    public double? MaxSquare { get; set; }

    public int? MinRoomsCount { get; set; }

    public int? MaxRoomsCount { get; set; }

    public int? MinFloor { get; set; }

    public int? MaxFloor { get; set; }
}
