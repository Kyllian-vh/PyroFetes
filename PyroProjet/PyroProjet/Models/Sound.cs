using System;
using System.Collections.Generic;

namespace PyroProjet.Models;

public partial class Sound
{
    public int Id { get; set; }

    public string? Label { get; set; }

    public string? Artist { get; set; }

    public int? LengthMs { get; set; }

    public string? Format { get; set; }

    public string? FilePath { get; set; }

    public virtual ICollection<PlaysSound> PlaysSounds { get; set; } = new List<PlaysSound>();
}
