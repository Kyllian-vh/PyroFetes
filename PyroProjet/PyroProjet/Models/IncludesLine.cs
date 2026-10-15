using System;
using System.Collections.Generic;

namespace PyroProjet.Models;

public partial class IncludesLine
{
    public int Id { get; set; }

    public int Id1 { get; set; }

    public int? Quantity { get; set; }

    public virtual DeliveryNoteLine Id1Navigation { get; set; } = null!;

    public virtual DeliveryNote IdNavigation { get; set; } = null!;
}
