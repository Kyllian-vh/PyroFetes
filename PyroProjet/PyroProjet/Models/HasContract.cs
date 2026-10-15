using System;
using System.Collections.Generic;

namespace PyroProjet.Models;

public partial class HasContract
{
    public int Id { get; set; }

    public int Id1 { get; set; }

    public decimal? Price { get; set; }

    public string? Subject { get; set; }

    public virtual ServiceProvider Id1Navigation { get; set; } = null!;

    public virtual Show IdNavigation { get; set; } = null!;
}
