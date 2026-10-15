namespace PyroFetes.Domain.Entities;

/// <summary>Société de transport qui achemine une livraison.</summary>
public class Transporteur
{
    public int Id { get; set; }
    public string Nom { get; set; } = string.Empty;

    /// <summary>Adresse de suivi en ligne, si le transporteur en propose une.</summary>
    public string? UrlSuivi { get; set; }

    public ICollection<BonLivraison> Livraisons { get; set; } = new List<BonLivraison>();
}

/// <summary>Bon de livraison issu de la transformation d'un bon de commande.</summary>
public class BonLivraison
{
    public int Id { get; set; }
    public DateTime DateExpedition { get; set; }
    public string? NumeroSuivi { get; set; }
    public DateTime DateLivraisonPrevue { get; set; }
    public DateTime? DateLivraisonEffective { get; set; }

    public int BonCommandeId { get; set; }
    public BonCommande BonCommande { get; set; } = null!;

    public int? TransporteurId { get; set; }
    public Transporteur? Transporteur { get; set; }

    public ICollection<Reception> Receptions { get; set; } = new List<Reception>();

    /// <summary>Vrai si la date prévue est dépassée sans livraison effective.</summary>
    public bool EstEnRetard(DateTime aujourdhui) =>
        DateLivraisonEffective is null && aujourdhui.Date > DateLivraisonPrevue.Date;
}

/// <summary>Réception physique des produits d'une livraison.</summary>
public class Reception
{
    public int Id { get; set; }
    public DateTime DateReception { get; set; } = DateTime.Now;
    public bool EstConforme { get; set; }
    public string? Commentaire { get; set; }

    public int BonLivraisonId { get; set; }
    public BonLivraison BonLivraison { get; set; } = null!;

    public ICollection<LigneReception> Lignes { get; set; } = new List<LigneReception>();
}

/// <summary>Contrôle d'un produit reçu : quantités reçue et conforme.</summary>
public class LigneReception
{
    public int Id { get; set; }
    public int QuantiteRecue { get; set; }
    public int QuantiteConforme { get; set; }
    public string? Anomalie { get; set; }

    public int ReceptionId { get; set; }
    public Reception Reception { get; set; } = null!;

    public int ProduitId { get; set; }
    public Produit Produit { get; set; } = null!;
}

/// <summary>Paramètres de personnalisation des devis et bons de commande.</summary>
public class ParametresDocument
{
    public int Id { get; set; }

    /// <summary>Chemin du logo affiché sur les documents.</summary>
    public string? CheminLogo { get; set; }

    public string? ConditionsVente { get; set; }
    public string? ConditionsAchat { get; set; }
    public string? MessageDefaut { get; set; }
}
