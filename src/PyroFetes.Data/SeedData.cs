using Microsoft.EntityFrameworkCore;
using PyroFetes.Domain.Entities;

namespace PyroFetes.Data;

/// <summary>
/// Données de test insérées par la migration initiale (produits, fournisseurs, transporteurs).
/// </summary>
internal static class SeedData
{
    public static void Appliquer(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Fournisseur>().HasData(
            new Fournisseur { Id = 1, Nom = "Artifices du Sud", Adresse = "12 rue des Étoiles, 13001 Marseille", Telephone = "04 91 00 00 01", Email = "contact@artifices-sud.fr" },
            new Fournisseur { Id = 2, Nom = "Pyro Nord Distribution", Adresse = "5 avenue de la Poudre, 59000 Lille", Telephone = "03 20 00 00 02", Email = "commandes@pyronord.fr" },
            new Fournisseur { Id = 3, Nom = "Lumières & Feux", Adresse = "8 quai du Feu, 69002 Lyon", Telephone = "04 72 00 00 03", Email = "ventes@lumieresetfeux.fr" });

        modelBuilder.Entity<Produit>().HasData(
            new Produit { Id = 1, Reference = "BOU-100", Libelle = "Bouquet final 100 coups", PrixVente = 189.90m, QuantiteStock = 12, SeuilMinimal = 5 },
            new Produit { Id = 2, Reference = "FUS-020", Libelle = "Fusées multicolores (lot de 20)", PrixVente = 49.90m, QuantiteStock = 40, SeuilMinimal = 15 },
            new Produit { Id = 3, Reference = "CHN-050", Libelle = "Chandelles romaines 50 mm", PrixVente = 24.50m, QuantiteStock = 6, SeuilMinimal = 10 },
            new Produit { Id = 4, Reference = "FON-003", Libelle = "Fontaine argentée 3 minutes", PrixVente = 14.90m, QuantiteStock = 60, SeuilMinimal = 20 },
            new Produit { Id = 5, Reference = "CER-SHOW", Libelle = "Kit spectacle mariage", PrixVente = 499.00m, QuantiteStock = 3, SeuilMinimal = 2 });

        modelBuilder.Entity<ProduitFournisseur>().HasData(
            new ProduitFournisseur { ProduitId = 1, FournisseurId = 1, PrixAchat = 110.00m, DelaiLivraisonJours = 7 },
            new ProduitFournisseur { ProduitId = 1, FournisseurId = 3, PrixAchat = 105.00m, DelaiLivraisonJours = 12 },
            new ProduitFournisseur { ProduitId = 2, FournisseurId = 2, PrixAchat = 28.00m, DelaiLivraisonJours = 5 },
            new ProduitFournisseur { ProduitId = 3, FournisseurId = 1, PrixAchat = 13.00m, DelaiLivraisonJours = 4 },
            new ProduitFournisseur { ProduitId = 3, FournisseurId = 2, PrixAchat = 12.50m, DelaiLivraisonJours = 6 },
            new ProduitFournisseur { ProduitId = 4, FournisseurId = 3, PrixAchat = 7.80m, DelaiLivraisonJours = 3 },
            new ProduitFournisseur { ProduitId = 5, FournisseurId = 1, PrixAchat = 320.00m, DelaiLivraisonJours = 10 });

        modelBuilder.Entity<Transporteur>().HasData(
            new Transporteur { Id = 1, Nom = "Transports ADR Express", UrlSuivi = null },
            new Transporteur { Id = 2, Nom = "Messagerie Matières Dangereuses", UrlSuivi = null });
    }
}
