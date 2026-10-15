using System;
using System.Collections.Generic;

namespace PyroProjet.Models;

public partial class Show
{
    public int Id { get; set; }

    public string? Label { get; set; }

    public string? Description { get; set; }

    public TimeOnly? Duration { get; set; }

    public DateOnly? Date { get; set; }

    public string? Address { get; set; }

    public string? SitePlan { get; set; }

    public int Id1 { get; set; }

    public int Id2 { get; set; }

    public virtual ICollection<HasContract> HasContracts { get; set; } = new List<HasContract>();

    public virtual Status Id1Navigation { get; set; } = null!;

    public virtual Customer Id2Navigation { get; set; } = null!;

    public virtual ICollection<PlaysSound> PlaysSounds { get; set; } = new List<PlaysSound>();

    public virtual ICollection<TriggersArticle> TriggersArticles { get; set; } = new List<TriggersArticle>();

    public virtual ICollection<Truck> Id1s { get; set; } = new List<Truck>();

    public virtual ICollection<Pyrotechnician> Id1sNavigation { get; set; } = new List<Pyrotechnician>();
}
