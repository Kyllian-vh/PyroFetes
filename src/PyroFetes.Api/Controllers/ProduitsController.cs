using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PyroFetes.Data;
using PyroFetes.Domain.Enums;
using PyroFetes.Services;

namespace PyroFetes.Api.Controllers;

/// <summary>Produits, niveaux de stock et réapprovisionnement.</summary>
[ApiController]
[Route("api/produits")]
public class ProduitsController : ControllerBase
{
    private readonly PyroFetesContext _context;
    private readonly ApprovisionnementService _appro;

    public ProduitsController(PyroFetesContext context, ApprovisionnementService appro)
    {
        _context = context;
        _appro = appro;
    }

    /// <summary>Liste les produits avec leur stock actuel et leur seuil minimal.</summary>
    [HttpGet]
    public async Task<IActionResult> Lister()
    {
        var produits = await _context.Produits
            .OrderBy(p => p.Libelle)
            .Select(p => new ProduitDto(p.Id, p.Reference, p.Libelle, p.QuantiteStock, p.SeuilMinimal, p.QuantiteStock <= p.SeuilMinimal))
            .ToListAsync();
        return Ok(produits);
    }

    /// <summary>Liste les produits au niveau minimal ou en dessous.</summary>
    [HttpGet("sous-seuil")]
    public async Task<IActionResult> ListerSousSeuil()
    {
        var produits = await _context.Produits
            .Where(p => p.QuantiteStock <= p.SeuilMinimal)
            .Select(p => new ProduitDto(p.Id, p.Reference, p.Libelle, p.QuantiteStock, p.SeuilMinimal, true))
            .ToListAsync();
        return Ok(produits);
    }

    /// <summary>Fournisseurs proposés pour un produit, du plus adapté au moins adapté.</summary>
    [HttpGet("{id:int}/fournisseurs")]
    public async Task<IActionResult> ProposerFournisseurs(int id)
    {
        var propositions = await _appro.ProposerFournisseursAsync(id);
        return Ok(propositions.Select(pf => new
        {
            pf.FournisseurId,
            pf.Fournisseur.Nom,
            pf.PrixAchat,
            pf.DelaiLivraisonJours
        }));
    }

    /// <summary>Modifie le niveau minimal de stock d'un produit.</summary>
    [HttpPut("{id:int}/seuil")]
    public async Task<IActionResult> ModifierSeuil(int id, [FromBody] int seuilMinimal)
    {
        if (seuilMinimal < 0) return BadRequest("Le seuil doit être positif ou nul.");

        var produit = await _context.Produits.FindAsync(id);
        if (produit is null) return NotFound();

        produit.SeuilMinimal = seuilMinimal;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    /// <summary>
    /// Enregistre une entrée ou une sortie de stock.
    /// Renvoie le bon de commande généré automatiquement si le seuil est atteint.
    /// </summary>
    [HttpPost("{id:int}/mouvements")]
    public async Task<IActionResult> EnregistrerMouvement(int id, [FromBody] MouvementDto mouvement)
    {
        try
        {
            var bon = await _appro.EnregistrerMouvementAsync(id, mouvement.Quantite, mouvement.Type, mouvement.Motif);
            return Ok(new { BonCommandeGenere = bon?.Numero });
        }
        catch (KeyNotFoundException) { return NotFound(); }
        catch (Exception ex) when (ex is ArgumentException or InvalidOperationException)
        {
            return BadRequest(ex.Message);
        }
    }
}

/// <summary>Produit tel qu'exposé par l'API.</summary>
public record ProduitDto(int Id, string Reference, string Libelle, int QuantiteStock, int SeuilMinimal, bool EstSousSeuil);

/// <summary>Mouvement de stock reçu par l'API.</summary>
public record MouvementDto(int Quantite, TypeMouvement Type, string? Motif);
