using System;
using System.Collections.Generic;

namespace PyroProjet.Models;

public partial class DeliveryNote
{
    public int Id { get; set; }

    public string? ReceptionRemarks { get; set; }

    public DateOnly? ShippingDate { get; set; }

    public DateOnly? CreationDate { get; set; }

    public string? Carrier { get; set; }

    public string? TrackingNumber { get; set; }

    public bool? IsCompliance { get; set; }

    public int Id1 { get; set; }

    public virtual PurchaseOrder Id1Navigation { get; set; } = null!;

    public virtual ICollection<IncludesLine> IncludesLines { get; set; } = new List<IncludesLine>();
}
