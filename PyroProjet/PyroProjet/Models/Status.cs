using System;
using System.Collections.Generic;

namespace PyroProjet.Models;

public partial class Status
{
    public int Id { get; set; }

    public string? Label { get; set; }

    public virtual ICollection<Show> Shows { get; set; } = new List<Show>();
}
