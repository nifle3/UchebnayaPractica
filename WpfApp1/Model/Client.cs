namespace WpfApp1.Model;

public sealed partial class Client
{
    public int Id { get; set; }

    public string? LastName { get; set; }

    public string? MiddleName { get; set; }

    public string? FirstName { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public ICollection<Need> Needs { get; set; } = new List<Need>();

    public ICollection<Suggestion> Suggestions { get; set; } = new List<Suggestion>();
}
