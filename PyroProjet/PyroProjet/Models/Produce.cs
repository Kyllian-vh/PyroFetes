using System;
using System.Collections.Generic;

namespace PyroProjet.Models;

public partial class Produce
{
    public int Id { get; set; }

    public int Id1 { get; set; }

    public int? Duration { get; set; }

    public virtual Effect Id1Navigation { get; set; } = null!;

    public virtual Product IdNavigation { get; set; } = null!;
}
