using System;
using System.Collections.Generic;

namespace PyroProjet.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Note { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public int Id1 { get; set; }

    public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();

    public virtual CustomerType Id1Navigation { get; set; } = null!;

    public virtual ICollection<Quotation> Quotations { get; set; } = new List<Quotation>();

    public virtual ICollection<Show> Shows { get; set; } = new List<Show>();
}
