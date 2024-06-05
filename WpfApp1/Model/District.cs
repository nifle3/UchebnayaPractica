namespace WpfApp1.Model;

public sealed partial class District
{
    public string Name { get; set; } = null!;

    public ICollection<Estate> Estates { get; set; } = new List<Estate>();
}
