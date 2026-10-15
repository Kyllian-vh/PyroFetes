using System;
using System.Collections.Generic;

namespace PyroProjet.Models;

public partial class Quotation
{
    public int Id { get; set; }

    public DateOnly? Date { get; set; }

    public string? Reference { get; set; }

    public string? Object { get; set; }

    public int Id1 { get; set; }

    public virtual Customer Id1Navigation { get; set; } = null!;

    public virtual ICollection<QuotationLine> QuotationLines { get; set; } = new List<QuotationLine>();
}
