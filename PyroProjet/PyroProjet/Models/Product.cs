using System;
using System.Collections.Generic;

namespace PyroProjet.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? EuClassification { get; set; }

    public decimal? CaliberMm { get; set; }

    public int? ApprovalNumber { get; set; }

    public decimal? SellPrice { get; set; }

    public DateOnly? ExpirationDate { get; set; }

    public decimal? NecGrams { get; set; }

    public int? WeightGrams { get; set; }

    public int? Duration { get; set; }

    public int Id1 { get; set; }

    public int? Id2 { get; set; }

    public int Id3 { get; set; }

    public virtual ProductFamily Id1Navigation { get; set; } = null!;

    public virtual Brand? Id2Navigation { get; set; }

    public virtual Article Id3Navigation { get; set; } = null!;

    public virtual ICollection<Produce> Produces { get; set; } = new List<Produce>();

    public virtual ICollection<Color> Id1s { get; set; } = new List<Color>();
}
