using System;
using System.Collections.Generic;

namespace PyroProjet.Models;

public partial class PurchaseOrder
{
    public int Id { get; set; }

    public DateOnly? Date { get; set; }

    public string? Label { get; set; }

    public int Id1 { get; set; }

    public virtual DeliveryNote? DeliveryNote { get; set; }

    public virtual Supplier Id1Navigation { get; set; } = null!;

    public virtual ICollection<OrdersArticle> OrdersArticles { get; set; } = new List<OrdersArticle>();
}
