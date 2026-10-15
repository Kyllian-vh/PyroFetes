using System;
using System.Collections.Generic;

namespace PyroProjet.Models;

public partial class Contain
{
    public int Id { get; set; }

    public int Id1 { get; set; }

    public int? TheoricalQuantity { get; set; }

    public int? PhysicalQuantity { get; set; }

    public virtual Inventory Id1Navigation { get; set; } = null!;

    public virtual Article IdNavigation { get; set; } = null!;
}
