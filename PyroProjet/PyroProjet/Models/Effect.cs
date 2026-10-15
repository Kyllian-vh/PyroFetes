using System;
using System.Collections.Generic;

namespace PyroProjet.Models;

public partial class Effect
{
    public int Id { get; set; }

    public string? Label { get; set; }

    public virtual ICollection<Produce> Produces { get; set; } = new List<Produce>();
}
