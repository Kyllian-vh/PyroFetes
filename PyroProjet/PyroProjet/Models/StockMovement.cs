using System;
using System.Collections.Generic;

namespace PyroProjet.Models;

public partial class StockMovement
{
    public int Id { get; set; }

    public string? Type { get; set; }

    public int? Quantity { get; set; }

    public DateOnly? Date { get; set; }

    public int Id1 { get; set; }

    public int? Id2 { get; set; }

    public int Id3 { get; set; }

    public int Id4 { get; set; }

    public virtual Article Id1Navigation { get; set; } = null!;

    public virtual Warehouse? Id2Navigation { get; set; }

    public virtual Warehouse Id3Navigation { get; set; } = null!;

    public virtual User Id4Navigation { get; set; } = null!;
}
