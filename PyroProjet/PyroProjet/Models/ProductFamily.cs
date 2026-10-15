using System;
using System.Collections.Generic;

namespace PyroProjet.Models;

public partial class ProductFamily
{
    public int Id { get; set; }

    public string? Label { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
