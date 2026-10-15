using System;
using System.Collections.Generic;

namespace PyroProjet.Models;

public partial class Consumable
{
    public int Id { get; set; }

    public string? UnitOfMeasurement { get; set; }

    public string? Category { get; set; }

    public int Id1 { get; set; }

    public virtual Article Id1Navigation { get; set; } = null!;
}
