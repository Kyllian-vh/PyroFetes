using System;
using System.Collections.Generic;

namespace PyroProjet.Models;

public partial class ServiceType
{
    public int Id { get; set; }

    public string? Label { get; set; }

    public virtual ICollection<ServiceProvider> Ids { get; set; } = new List<ServiceProvider>();
}
