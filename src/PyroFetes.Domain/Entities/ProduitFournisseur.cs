namespace PyroFetes.Domain.Entities;

/// <summary>
/// Association entre un produit et un fournisseur (relation N–N porteuse de données).
/// </summary>
public class ProduitFournisseur
{
    public int ProduitId { get; set; }
    public Produit Produit { get; set; } = null!;

    public int FournisseurId { get; set; }
    public Fournisseur Fournisseur { get; set; } = null!;

    /// <summary>Prix d'achat unitaire chez ce fournisseur.</summary>
    public decimal PrixAchat { get; set; }

    /// <summary>Délai de livraison de ce produit par ce fournisseur, en jours.</summary>
    public int DelaiLivraisonJours { get; set; }
}
