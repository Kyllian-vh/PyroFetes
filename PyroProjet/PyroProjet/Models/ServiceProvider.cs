using System;
using System.Collections.Generic;

namespace PyroProjet.Models;

public partial class ServiceProvider
{
    public int Id { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<HasContract> HasContracts { get; set; } = new List<HasContract>();

    public virtual ICollection<ServiceType> Id1s { get; set; } = new List<ServiceType>();
}
