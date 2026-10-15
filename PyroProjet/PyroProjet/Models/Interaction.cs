using System;
using System.Collections.Generic;

namespace PyroProjet.Models;

public partial class Interaction
{
    public int Id { get; set; }

    public DateTime? DateTime { get; set; }

    public string? Call { get; set; }

    public string? Email { get; set; }

    public string? Meeting { get; set; }

    public int Id1 { get; set; }

    public virtual Contact Id1Navigation { get; set; } = null!;
}
