namespace WpfApp1.Model;

public sealed partial class Realtor
{
    public int Id { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string MiddleName { get; set; } = null!;

    public int? Comission { get; set; }

    public ICollection<Need> Needs { get; set; } = new List<Need>();

    public ICollection<Suggestion> Suggestions { get; set; } = new List<Suggestion>();
}
