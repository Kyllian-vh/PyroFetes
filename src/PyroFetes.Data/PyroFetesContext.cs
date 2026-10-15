using Microsoft.EntityFrameworkCore;
using PyroFetes.Domain.Entities;

namespace PyroFetes.Data;

/// <summary>
/// Contexte Entity Framework Core du module Achats et Livraisons.
/// Les règles de mapping sont centralisées dans <see cref="OnModelCreating"/>.
/// </summary>
public class PyroFetesContext : DbContext
{
    public PyroFetesContext(DbContextOptions<PyroFetesContext> options) : base(options) { }

    public DbSet<Produit> Produits => Set<Produit>();
    public DbSet<Fournisseur> Fournisseurs => Set<Fournisseur>();
    public DbSet<ProduitFournisseur> ProduitsFournisseurs => Set<ProduitFournisseur>();
    public DbSet<MouvementStock> MouvementsStock => Set<MouvementStock>();
    public DbSet<Client> Clients => Set<Client>();
    public DbSet<Devis> Devis => Set<Devis>();
    public DbSet<LigneDevis> LignesDevis => Set<LigneDevis>();
    public DbSet<BonCommande> BonsCommande => Set<BonCommande>();
    public DbSet<LigneCommande> LignesCommande => Set<LigneCommande>();
    public DbSet<BonLivraison> BonsLivraison => Set<BonLivraison>();
    public DbSet<Transporteur> Transporteurs => Set<Transporteur>();
    public DbSet<Reception> Receptions => Set<Reception>();
    public DbSet<LigneReception> LignesReception => Set<LigneReception>();
    public DbSet<ParametresDocument> ParametresDocuments => Set<ParametresDocument>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Produit : référence unique, propriété calculée non persistée.
        modelBuilder.Entity<Produit>(e =>
        {
            e.HasIndex(p => p.Reference).IsUnique();
            e.Property(p => p.Reference).HasMaxLength(50).IsRequired();
            e.Property(p => p.Libelle).HasMaxLength(200).IsRequired();
            e.Property(p => p.PrixVente).HasPrecision(10, 2);
            e.Ignore(p => p.EstSousSeuil);
        });

        modelBuilder.Entity<Fournisseur>(e =>
        {
            e.Property(f => f.Nom).HasMaxLength(150).IsRequired();
        });

        // Association N–N porteuse de données : clé composite.
        modelBuilder.Entity<ProduitFournisseur>(e =>
        {
            e.HasKey(pf => new { pf.ProduitId, pf.FournisseurId });
            e.Property(pf => pf.PrixAchat).HasPrecision(10, 2);
            e.HasOne(pf => pf.Produit).WithMany(p => p.Fournisseurs).HasForeignKey(pf => pf.ProduitId);
            e.HasOne(pf => pf.Fournisseur).WithMany(f => f.Produits).HasForeignKey(pf => pf.FournisseurId);
        });

        modelBuilder.Entity<Devis>(e =>
        {
            e.HasIndex(d => d.Numero).IsUnique();
            e.Ignore(d => d.Total);
        });
        modelBuilder.Entity<LigneDevis>().Property(l => l.PrixUnitaire).HasPrecision(10, 2);

        modelBuilder.Entity<BonCommande>(e =>
        {
            e.HasIndex(b => b.Numero).IsUnique();
            e.Ignore(b => b.Total);
            // Un bon de commande donne au plus un bon de livraison.
            e.HasOne(b => b.BonLivraison)
             .WithOne(l => l.BonCommande)
             .HasForeignKey<BonLivraison>(l => l.BonCommandeId);
        });
        modelBuilder.Entity<LigneCommande>().Property(l => l.PrixUnitaire).HasPrecision(10, 2);

        // Les lignes référencent des produits : pas de suppression en cascade sur le produit.
        modelBuilder.Entity<LigneCommande>()
            .HasOne(l => l.Produit).WithMany().OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<LigneDevis>()
            .HasOne(l => l.Produit).WithMany().OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<LigneReception>()
            .HasOne(l => l.Produit).WithMany().OnDelete(DeleteBehavior.Restrict);

        SeedData.Appliquer(modelBuilder);
    }
}
