using System;
using System.Collections.Generic;

namespace PyroProjet.Models;

public partial class Approval
{
    public int Id { get; set; }

    public DateOnly? ObtainedDate { get; set; }

    public string? FilePathCertification { get; set; }

    public virtual ICollection<Pyrotechnician> Ids { get; set; } = new List<Pyrotechnician>();
}
