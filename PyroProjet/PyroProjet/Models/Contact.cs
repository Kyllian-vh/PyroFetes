using System;
using System.Collections.Generic;

namespace PyroProjet.Models;

public partial class Contact
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Title { get; set; }

    public string? Role { get; set; }

    public string? Email { get; set; }

    public int Id1 { get; set; }

    public virtual Customer Id1Navigation { get; set; } = null!;

    public virtual ICollection<Interaction> Interactions { get; set; } = new List<Interaction>();
}
