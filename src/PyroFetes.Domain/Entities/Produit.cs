namespace PyroFetes.Domain.Entities;

/// <summary>
/// Produit pyrotechnique géré en stock.
/// </summary>
public class Produit
{
    public int Id { get; set; }

    /// <summary>Référence interne unique du produit.</summary>
    public string Reference { get; set; } = string.Empty;

    public string Libelle { get; set; } = string.Empty;

    public decimal PrixVente { get; set; }

    /// <summary>Quantité actuellement en stock.</summary>
    public int QuantiteStock { get; set; }

    /// <summary>
    /// Niveau minimal de stock. Quand <see cref="QuantiteStock"/> atteint ou passe
    /// sous ce seuil, un bon de commande est généré automatiquement.
    /// </summary>
    public int SeuilMinimal { get; set; }

    public ICollection<ProduitFournisseur> Fournisseurs { get; set; } = new List<ProduitFournisseur>();
    public ICollection<MouvementStock> Mouvements { get; set; } = new List<MouvementStock>();

    /// <summary>Indique si le produit doit être réapprovisionné.</summary>
    public bool EstSousSeuil => QuantiteStock <= SeuilMinimal;
}
