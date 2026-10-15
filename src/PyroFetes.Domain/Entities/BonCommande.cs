using PyroFetes.Domain.Enums;

namespace PyroFetes.Domain.Entities;

/// <summary>Bon de commande passé auprès d'un fournisseur.</summary>
public class BonCommande
{
    public int Id { get; set; }
    public string Numero { get; set; } = string.Empty;
    public DateTime Date { get; set; } = DateTime.Now;
    public StatutCommande Statut { get; set; } = StatutCommande.Brouillon;

    /// <summary>Vrai si le bon a été généré automatiquement suite à un passage sous le seuil minimal.</summary>
    public bool EstAutomatique { get; set; }

    public int FournisseurId { get; set; }
    public Fournisseur Fournisseur { get; set; } = null!;

    public ICollection<LigneCommande> Lignes { get; set; } = new List<LigneCommande>();

    /// <summary>Bon de livraison créé une fois les produits expédiés (null avant expédition).</summary>
    public BonLivraison? BonLivraison { get; set; }

    /// <summary>Montant total du bon de commande.</summary>
    public decimal Total => Lignes.Sum(l => l.Quantite * l.PrixUnitaire);
}

/// <summary>Ligne d'un bon de commande.</summary>
public class LigneCommande
{
    public int Id { get; set; }
    public int Quantite { get; set; }
    public decimal PrixUnitaire { get; set; }

    public int BonCommandeId { get; set; }
    public BonCommande BonCommande { get; set; } = null!;

    public int ProduitId { get; set; }
    public Produit Produit { get; set; } = null!;
}
