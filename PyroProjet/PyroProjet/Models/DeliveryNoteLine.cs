using System;
using System.Collections.Generic;

namespace PyroProjet.Models;

public partial class DeliveryNoteLine
{
    public int Id { get; set; }

    public string? Label { get; set; }

    public virtual ICollection<IncludesLine> IncludesLines { get; set; } = new List<IncludesLine>();
}
