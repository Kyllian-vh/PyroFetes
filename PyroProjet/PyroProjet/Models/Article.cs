using System;
using System.Collections.Generic;

namespace PyroProjet.Models;

public partial class Article
{
    public int Id { get; set; }

    public string? Reference { get; set; }

    public bool? VisibilityState { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Sellable { get; set; }

    public virtual Consumable? Consumable { get; set; }

    public virtual ICollection<Contain> Contains { get; set; } = new List<Contain>();

    public virtual Material? Material { get; set; }

    public virtual ICollection<Medium> Media { get; set; } = new List<Medium>();

    public virtual ICollection<OrdersArticle> OrdersArticles { get; set; } = new List<OrdersArticle>();

    public virtual Product? Product { get; set; }

    public virtual ICollection<StockMovement> StockMovements { get; set; } = new List<StockMovement>();

    public virtual ICollection<Store> Stores { get; set; } = new List<Store>();

    public virtual ICollection<TriggersArticle> TriggersArticles { get; set; } = new List<TriggersArticle>();

    public virtual ICollection<Truck> Id1s { get; set; } = new List<Truck>();
}
