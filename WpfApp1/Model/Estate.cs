﻿namespace WpfApp1.Model;

public partial class Estate
{
    public int Id { get; set; }

    public int? Address { get; set; }

    public string? District { get; set; }

    public string EstateType { get; set; } = null!;

    public virtual Address? AddressNavigation { get; set; }

    public virtual District? DistrictNavigation { get; set; }

    public virtual ICollection<Suggestion> Suggestions { get; set; } = new List<Suggestion>();
}
