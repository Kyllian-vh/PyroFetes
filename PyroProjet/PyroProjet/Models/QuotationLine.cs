using System;
using System.Collections.Generic;

namespace PyroProjet.Models;

public partial class QuotationLine
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public int? Quantity { get; set; }

    public string? Label { get; set; }

    public string? Unit { get; set; }

    public decimal? PriceHt { get; set; }

    public int Id1 { get; set; }

    public virtual Quotation Id1Navigation { get; set; } = null!;
}
