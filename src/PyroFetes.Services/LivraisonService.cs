using Microsoft.EntityFrameworkCore;
using PyroFetes.Data;
using PyroFetes.Domain.Entities;
using PyroFetes.Domain.Enums;

namespace PyroFetes.Services;

/// <summary>
/// Règles métier des livraisons : transformation d'un bon de commande et suivi des retards
/// (tickets GDP-12 et GDP-15).
/// </summary>
public class LivraisonService
{
    private readonly PyroFetesContext _context;

    public LivraisonService(PyroFetesContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Transforme un bon de commande envoyé en bon de livraison une fois les produits expédiés.
    /// La date prévue est calculée à partir du plus long délai fournisseur des produits commandés.
    /// </summary>
    public async Task<BonLivraison> TransformerEnLivraisonAsync(int bonCommandeId, DateTime dateExpedition, int? transporteurId = null, string? numeroSuivi = null)
    {
        var bon = await _context.BonsCommande
            .Include(b => b.Lignes)
            .Include(b => b.BonLivraison)
            .FirstOrDefaultAsync(b => b.Id == bonCommandeId)
            ?? throw new KeyNotFoundException($"Bon de commande {bonCommandeId} introuvable.");

        if (bon.BonLivraison is not null)
            throw new InvalidOperationException("Ce bon de commande a déjà été transformé en bon de livraison.");
        if (bon.Statut != StatutCommande.Envoyee)
            throw new InvalidOperationException("Seul un bon de commande envoyé peut être transformé.");

        var produitIds = bon.Lignes.Select(l => l.ProduitId).ToList();
        int delaiMax = await _context.ProduitsFournisseurs
            .Where(pf => pf.FournisseurId == bon.FournisseurId && produitIds.Contains(pf.ProduitId))
            .Select(pf => (int?)pf.DelaiLivraisonJours)
            .MaxAsync() ?? 0;

        var livraison = new BonLivraison
        {
            BonCommandeId = bon.Id,
            DateExpedition = dateExpedition,
            DateLivraisonPrevue = dateExpedition.AddDays(delaiMax),
            TransporteurId = transporteurId,
            NumeroSuivi = numeroSuivi
        };

        bon.Statut = StatutCommande.Expediee;
        _context.BonsLivraison.Add(livraison);
        await _context.SaveChangesAsync();
        return livraison;
    }

    /// <summary>Livraisons dont la date prévue est dépassée sans livraison effective.</summary>
    public async Task<List<BonLivraison>> ListerRetardsAsync(DateTime aujourdhui)
    {
        var jour = aujourdhui.Date;
        return await _context.BonsLivraison
            .Include(l => l.BonCommande).ThenInclude(b => b.Fournisseur)
            .Include(l => l.Transporteur)
            .Where(l => l.DateLivraisonEffective == null && l.DateLivraisonPrevue < jour)
            .OrderBy(l => l.DateLivraisonPrevue)
            .ToListAsync();
    }
}
