namespace PyroFetes.Domain.Entities;

/// <summary>
/// Fournisseur auprès duquel Pyro-Fêtes s'approvisionne.
/// </summary>
public class Fournisseur
{
    public int Id { get; set; }
    public string Nom { get; set; } = string.Empty;
    public string Adresse { get; set; } = string.Empty;
    public string Telephone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    /// <summary>Produits fournis, avec prix d'achat et délai propres à chaque produit.</summary>
    public ICollection<ProduitFournisseur> Produits { get; set; } = new List<ProduitFournisseur>();

    public ICollection<BonCommande> BonsCommande { get; set; } = new List<BonCommande>();
}
