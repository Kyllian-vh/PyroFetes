using System;
using System.Collections.Generic;

namespace PyroProjet.Models;

public partial class Inventory
{
    public int Id { get; set; }

    public DateTime? Date { get; set; }

    public int Id1 { get; set; }

    public int Id2 { get; set; }

    public virtual ICollection<Contain> Contains { get; set; } = new List<Contain>();

    public virtual Warehouse Id1Navigation { get; set; } = null!;

    public virtual User Id2Navigation { get; set; } = null!;
}
