using System;
using System.Collections.Generic;

namespace PyroProjet.Models;

public partial class TriggersArticle
{
    public int Id { get; set; }

    public int Id1 { get; set; }

    public DateTime? Timecode { get; set; }

    public virtual Article Id1Navigation { get; set; } = null!;

    public virtual Show IdNavigation { get; set; } = null!;
}
