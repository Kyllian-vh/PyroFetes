using Microsoft.AspNetCore.Mvc;
using PyroFetes.Services;

namespace PyroFetes.Api.Controllers;

/// <summary>Suivi des livraisons fournisseurs.</summary>
[ApiController]
[Route("api/livraisons")]
public class LivraisonsController : ControllerBase
{
    private readonly LivraisonService _livraisons;

    public LivraisonsController(LivraisonService livraisons)
    {
        _livraisons = livraisons;
    }

    /// <summary>Livraisons dont la date prévue est dépassée sans livraison effective.</summary>
    [HttpGet("en-retard")]
    public async Task<IActionResult> ListerRetards()
    {
        var retards = await _livraisons.ListerRetardsAsync(DateTime.Now);
        return Ok(retards.Select(l => new
        {
            l.Id,
            BonCommande = l.BonCommande.Numero,
            Fournisseur = l.BonCommande.Fournisseur.Nom,
            Transporteur = l.Transporteur?.Nom,
            l.NumeroSuivi,
            l.DateLivraisonPrevue,
            JoursDeRetard = (DateTime.Now.Date - l.DateLivraisonPrevue.Date).Days
        }));
    }
}
