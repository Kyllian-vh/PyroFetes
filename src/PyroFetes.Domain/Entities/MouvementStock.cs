using PyroFetes.Domain.Enums;

namespace PyroFetes.Domain.Entities;

/// <summary>
/// Entrée ou sortie de stock d'un produit.
/// </summary>
public class MouvementStock
{
    public int Id { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;

    /// <summary>Quantité déplacée, toujours positive ; le sens est donné par <see cref="Type"/>.</summary>
    public int Quantite { get; set; }

    public TypeMouvement Type { get; set; }
    public string? Motif { get; set; }

    public int ProduitId { get; set; }
    public Produit Produit { get; set; } = null!;
}
