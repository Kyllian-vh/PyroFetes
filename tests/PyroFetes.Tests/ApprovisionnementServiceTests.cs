using Microsoft.EntityFrameworkCore;
using PyroFetes.Data;
using PyroFetes.Domain.Entities;
using PyroFetes.Domain.Enums;
using PyroFetes.Services;

namespace PyroFetes.Tests;

/// <summary>Tests des règles de réapprovisionnement (base en mémoire, isolée par test).</summary>
public class ApprovisionnementServiceTests
{
    private static PyroFetesContext CreerContexte()
    {
        var options = new DbContextOptionsBuilder<PyroFetesContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        var context = new PyroFetesContext(options);

        context.Fournisseurs.AddRange(
            new Fournisseur { Id = 1, Nom = "Rapide mais cher" },
            new Fournisseur { Id = 2, Nom = "Lent mais moins cher" });
        context.Produits.Add(new Produit { Id = 1, Reference = "TEST-1", Libelle = "Produit test", QuantiteStock = 10, SeuilMinimal = 5 });
        context.ProduitsFournisseurs.AddRange(
            new ProduitFournisseur { ProduitId = 1, FournisseurId = 1, PrixAchat = 20m, DelaiLivraisonJours = 2 },
            new ProduitFournisseur { ProduitId = 1, FournisseurId = 2, PrixAchat = 15m, DelaiLivraisonJours = 8 });
        context.SaveChanges();
        return context;
    }

    [Fact]
    public async Task SortieAuDessusDuSeuil_NeGenerePasDeBonDeCommande()
    {
        using var context = CreerContexte();
        var service = new ApprovisionnementService(context);

        var bon = await service.EnregistrerMouvementAsync(1, 3, TypeMouvement.Sortie);

        Assert.Null(bon);
        Assert.Equal(7, (await context.Produits.FindAsync(1))!.QuantiteStock);
    }

    [Fact]
    public async Task SortieQuiAtteintLeSeuil_GenereUnBonAutomatique()
    {
        using var context = CreerContexte();
        var service = new ApprovisionnementService(context);

        var bon = await service.EnregistrerMouvementAsync(1, 5, TypeMouvement.Sortie);

        Assert.NotNull(bon);
        Assert.True(bon!.EstAutomatique);
        Assert.Equal(StatutCommande.Brouillon, bon.Statut);
        // Stock à 5, seuil à 5 : on commande pour remonter à 2 × 5 = 10.
        Assert.Equal(5, bon.Lignes.Single().Quantite);
    }

    [Fact]
    public async Task GenerationAutomatique_ChoisitLeFournisseurLePlusRapide()
    {
        using var context = CreerContexte();
        var service = new ApprovisionnementService(context);

        var bon = await service.EnregistrerMouvementAsync(1, 6, TypeMouvement.Sortie);

        Assert.Equal(1, bon!.FournisseurId);
        Assert.Equal(20m, bon.Lignes.Single().PrixUnitaire);
    }

    [Fact]
    public async Task CommandeDejaEnCours_PasDeDoublon()
    {
        using var context = CreerContexte();
        var service = new ApprovisionnementService(context);

        var premier = await service.EnregistrerMouvementAsync(1, 6, TypeMouvement.Sortie);
        var second = await service.EnregistrerMouvementAsync(1, 1, TypeMouvement.Sortie);

        Assert.NotNull(premier);
        Assert.Null(second);
        Assert.Equal(1, await context.BonsCommande.CountAsync());
    }

    [Fact]
    public async Task SortieSuperieureAuStock_EstRefusee()
    {
        using var context = CreerContexte();
        var service = new ApprovisionnementService(context);

        await Assert.ThrowsAsync<InvalidOperationException>(
            () => service.EnregistrerMouvementAsync(1, 50, TypeMouvement.Sortie));
    }
}
