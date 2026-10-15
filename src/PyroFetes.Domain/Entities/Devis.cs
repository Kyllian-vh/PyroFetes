using PyroFetes.Domain.Enums;

namespace PyroFetes.Domain.Entities;

/// <summary>Client destinataire des devis.</summary>
public class Client
{
    public int Id { get; set; }
    public string Nom { get; set; } = string.Empty;
    public string Adresse { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public ICollection<Devis> Devis { get; set; } = new List<Devis>();
}

/// <summary>Devis adressé à un client.</summary>
public class Devis
{
    public int Id { get; set; }
    public string Numero { get; set; } = string.Empty;
    public DateTime Date { get; set; } = DateTime.Now;

    /// <summary>Message personnalisé affiché sur le devis.</summary>
    public string? Message { get; set; }

    public StatutDevis Statut { get; set; } = StatutDevis.Brouillon;

    public int ClientId { get; set; }
    public Client Client { get; set; } = null!;

    public ICollection<LigneDevis> Lignes { get; set; } = new List<LigneDevis>();

    /// <summary>Montant total du devis.</summary>
    public decimal Total => Lignes.Sum(l => l.Quantite * l.PrixUnitaire);
}

/// <summary>Ligne d'un devis : un produit, une quantité, un prix.</summary>
public class LigneDevis
{
    public int Id { get; set; }
    public int Quantite { get; set; }
    public decimal PrixUnitaire { get; set; }

    public int DevisId { get; set; }
    public Devis Devis { get; set; } = null!;

    public int ProduitId { get; set; }
    public Produit Produit { get; set; } = null!;
}
