namespace PyroFetes.Domain.Enums;

/// <summary>Cycle de vie d'un bon de commande.</summary>
public enum StatutCommande
{
    Brouillon,
    Envoyee,
    Expediee,
    Livree,
    Annulee
}

/// <summary>Cycle de vie d'un devis.</summary>
public enum StatutDevis
{
    Brouillon,
    Envoye,
    Accepte,
    Refuse
}

/// <summary>Sens d'un mouvement de stock.</summary>
public enum TypeMouvement
{
    Entree,
    Sortie
}
