using System;
using System.Collections.Generic;

namespace PyroProjet.Models;

public partial class Store
{
    public int Id { get; set; }

    public int Id1 { get; set; }

    public int? Quantity { get; set; }

    public virtual Warehouse Id1Navigation { get; set; } = null!;

    public virtual Article IdNavigation { get; set; } = null!;
}
