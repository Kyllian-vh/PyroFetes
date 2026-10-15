using Microsoft.EntityFrameworkCore;
using PyroFetes.Data;
using PyroFetes.Domain.Entities;
using PyroFetes.Domain.Enums;

namespace PyroFetes.Services;

/// <summary>
/// Règles métier du réapprovisionnement : mouvements de stock, proposition de fournisseurs
/// et génération automatique des bons de commande (tickets GDP-6, GDP-9, GDP-10, GDP-11).
/// </summary>
public class ApprovisionnementService
{
    private readonly PyroFetesContext _context;

    public ApprovisionnementService(PyroFetesContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Enregistre une entrée ou une sortie de stock, met à jour la quantité du produit
    /// puis génère un bon de commande si le stock atteint le seuil minimal.
    /// </summary>
    /// <returns>Le bon de commande généré, ou null si aucun n'était nécessaire.</returns>
    public async Task<BonCommande?> EnregistrerMouvementAsync(int produitId, int quantite, TypeMouvement type, string? motif = null)
    {
        if (quantite <= 0)
            throw new ArgumentOutOfRangeException(nameof(quantite), "La quantité doit être positive.");

        var produit = await _context.Produits.FindAsync(produitId)
            ?? throw new KeyNotFoundException($"Produit {produitId} introuvable.");

        if (type == TypeMouvement.Sortie && quantite > produit.QuantiteStock)
            throw new InvalidOperationException("Stock insuffisant pour cette sortie.");

        produit.QuantiteStock += type == TypeMouvement.Entree ? quantite : -quantite;
        _context.MouvementsStock.Add(new MouvementStock
        {
            ProduitId = produitId,
            Quantite = quantite,
            Type = type,
            Motif = motif
        });
        await _context.SaveChangesAsync();

        return await GenererBonCommandeSiNecessaireAsync(produit);
    }

    /// <summary>
    /// Fournisseurs d'un produit, du plus adapté au moins adapté :
    /// délai de livraison le plus court d'abord, puis prix d'achat le plus bas.
    /// </summary>
    public async Task<List<ProduitFournisseur>> ProposerFournisseursAsync(int produitId)
    {
        return await _context.ProduitsFournisseurs
            .Include(pf => pf.Fournisseur)
            .Where(pf => pf.ProduitId == produitId)
            .OrderBy(pf => pf.DelaiLivraisonJours)
            .ThenBy(pf => pf.PrixAchat)
            .ToListAsync();
    }

    /// <summary>
    /// Vérifie tous les produits et génère les bons de commande manquants.
    /// Prévu pour un contrôle périodique (tâche de fond quotidienne).
    /// </summary>
    public async Task<List<BonCommande>> VerifierTousLesSeuilsAsync()
    {
        var produitsSousSeuil = await _context.Produits
            .Where(p => p.QuantiteStock <= p.SeuilMinimal)
            .ToListAsync();

        var bons = new List<BonCommande>();
        foreach (var produit in produitsSousSeuil)
        {
            var bon = await GenererBonCommandeSiNecessaireAsync(produit);
            if (bon is not null) bons.Add(bon);
        }
        return bons;
    }

    /// <summary>
    /// Crée un bon de commande « Brouillon » automatique pour un produit sous son seuil,
    /// sauf si une commande est déjà en cours pour ce produit (évite les doublons).
    /// La quantité commandée remonte le stock au double du seuil minimal.
    /// </summary>
    private async Task<BonCommande?> GenererBonCommandeSiNecessaireAsync(Produit produit)
    {
        if (!produit.EstSousSeuil)
            return null;

        bool commandeEnCours = await _context.LignesCommande.AnyAsync(l =>
            l.ProduitId == produit.Id &&
            (l.BonCommande.Statut == StatutCommande.Brouillon ||
             l.BonCommande.Statut == StatutCommande.Envoyee ||
             l.BonCommande.Statut == StatutCommande.Expediee));
        if (commandeEnCours)
            return null;

        var meilleur = (await ProposerFournisseursAsync(produit.Id)).FirstOrDefault();
        if (meilleur is null)
            return null; // Aucun fournisseur affecté : impossible de commander automatiquement.

        int quantite = Math.Max(1, produit.SeuilMinimal * 2 - produit.QuantiteStock);

        var bon = new BonCommande
        {
            Numero = $"BC-AUTO-{DateTime.Now:yyyyMMddHHmmss}-{produit.Id}",
            FournisseurId = meilleur.FournisseurId,
            EstAutomatique = true,
            Statut = StatutCommande.Brouillon,
            Lignes =
            {
                new LigneCommande
                {
                    ProduitId = produit.Id,
                    Quantite = quantite,
                    PrixUnitaire = meilleur.PrixAchat
                }
            }
        };

        _context.BonsCommande.Add(bon);
        await _context.SaveChangesAsync();
        return bon;
    }
}
