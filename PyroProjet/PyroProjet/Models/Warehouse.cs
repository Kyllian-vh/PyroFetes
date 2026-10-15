using System;
using System.Collections.Generic;

namespace PyroProjet.Models;

public partial class Warehouse
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public int? MaxCapacity { get; set; }

    public int? LowThreshold { get; set; }

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();

    public virtual ICollection<StockMovement> StockMovementId2Navigations { get; set; } = new List<StockMovement>();

    public virtual ICollection<StockMovement> StockMovementId3Navigations { get; set; } = new List<StockMovement>();

    public virtual ICollection<Store> Stores { get; set; } = new List<Store>();
}
