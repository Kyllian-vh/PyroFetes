using System;
using System.Collections.Generic;

namespace PyroProjet.Models;

public partial class PlaysSound
{
    public int Id { get; set; }

    public int Id1 { get; set; }

    public DateTime? Timecode { get; set; }

    public int? Duration { get; set; }

    public int? StartSound { get; set; }

    public virtual Sound Id1Navigation { get; set; } = null!;

    public virtual Show IdNavigation { get; set; } = null!;
}
