using System;
using System.Collections.Generic;

namespace PyroProjet.Models;

public partial class Setting
{
    public int Id { get; set; }

    public string? Logo { get; set; }

    public string? PurchaseOrderCondition { get; set; }

    public string? QuotationCondition { get; set; }
}
