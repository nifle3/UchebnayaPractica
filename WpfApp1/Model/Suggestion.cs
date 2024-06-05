namespace WpfApp1.Model;

public sealed partial class Suggestion
{
    public int Id { get; set; }

    public int Client { get; set; }

    public int Realtor { get; set; }

    public int Estate { get; set; }

    public decimal Price { get; set; }

    public Client ClientNavigation { get; set; } = null!;

    public Estate EstateNavigation { get; set; } = null!;

    public Realtor RealtorNavigation { get; set; } = null!;

    public ICollection<Need> Needs { get; set; } = new List<Need>();
}
