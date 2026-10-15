using System;
using System.Collections.Generic;

namespace PyroProjet.Models;

public partial class Truck
{
    public int Id { get; set; }

    public int? Capacity { get; set; }

    public int? Size { get; set; }

    public string? LicensePlate { get; set; }

    public virtual ICollection<Show> Ids { get; set; } = new List<Show>();

    public virtual ICollection<Article> IdsNavigation { get; set; } = new List<Article>();
}
