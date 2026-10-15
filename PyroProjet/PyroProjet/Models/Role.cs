using System;
using System.Collections.Generic;

namespace PyroProjet.Models;

public partial class Role
{
    public int Id { get; set; }

    public string? Label { get; set; }

    public virtual ICollection<User> Ids { get; set; } = new List<User>();
}
