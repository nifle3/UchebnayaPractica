namespace WpfApp1.Model;

public sealed partial class ApartmentsNeed : Need
{
    public int? MinSquare { get; set; }

    public int? MaxSquare { get; set; }

    public int? MinRoomsCount { get; set; }

    public int? MaxRoomsCount { get; set; }

    public int? MinFloor { get; set; }

    public int? MaxFloor { get; set; }
}
