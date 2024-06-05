namespace WpfApp1.Model;

public partial class Need
{
    public int Id { get; set; }

    public int Client { get; set; }

    public int Realtor { get; set; }

    public int? Address { get; set; }

    public string EstateType { get; set; } = null!;

    public decimal? MinPrice { get; set; }

    public decimal? MaxPrice { get; set; }

    public virtual Address? AddressNavigation { get; set; }

    public virtual Client ClientNavigation { get; set; } = null!;

    public virtual Realtor RealtorNavigation { get; set; } = null!;

    public virtual ICollection<Suggestion> Suggestions { get; set; } = new List<Suggestion>();
}
