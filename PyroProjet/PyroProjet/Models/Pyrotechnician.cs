using System;
using System.Collections.Generic;

namespace PyroProjet.Models;

public partial class Pyrotechnician
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? LicenseNumber { get; set; }

    public virtual ICollection<Approval> Id1s { get; set; } = new List<Approval>();

    public virtual ICollection<Show> Ids { get; set; } = new List<Show>();
}
