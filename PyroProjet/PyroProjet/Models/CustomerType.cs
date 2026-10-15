using System;
using System.Collections.Generic;

namespace PyroProjet.Models;

public partial class CustomerType
{
    public int Id { get; set; }

    public string? Label { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
