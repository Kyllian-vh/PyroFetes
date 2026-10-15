using System;
using System.Collections.Generic;

namespace PyroProjet.Models;

public partial class Medium
{
    public int Id { get; set; }

    public string? Url { get; set; }

    public int Id1 { get; set; }

    public virtual Article Id1Navigation { get; set; } = null!;
}
