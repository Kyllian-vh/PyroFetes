using System;
using System.Collections.Generic;

namespace PyroProjet.Models;

public partial class Color
{
    public int Id { get; set; }

    public string? Label { get; set; }

    public virtual ICollection<Product> Ids { get; set; } = new List<Product>();
}
