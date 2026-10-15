# Pyro-Fêtes – Gestion des Achats et des Livraisons

Projet BTS SIO SLAM (sujet 2) : module de gestion des achats et des livraisons pour Pyro-Fêtes.
Il couvre les niveaux minimaux de stock et la génération automatique des bons de commande,
les devis et bons de commande en PDF, puis la transformation en bons de livraison et le suivi des réceptions.

Stack : C# / .NET 8, ASP.NET Core Web API, Entity Framework Core 8 (Code First), SQL Server, xUnit.

## Structure de la solution

| Projet | Rôle |
| --- | --- |
| `src/PyroFetes.Domain` | Entités et énumérations (aucune dépendance) |
| `src/PyroFetes.Data` | `PyroFetesContext`, mapping EF Core, données de test, migrations |
| `src/PyroFetes.Services` | Règles métier (réapprovisionnement, livraisons) |
| `src/PyroFetes.Api` | API REST, Swagger, tâche de fond quotidienne |
| `tests/PyroFetes.Tests` | Tests unitaires xUnit sur base en mémoire |

Le front (Blazor, MVC ou WPF) sera ajouté dans `src/` une fois la technologie choisie.

## Installation

Prérequis : .NET 8 SDK, SQL Server LocalDB (installé avec Visual Studio), outil EF :

```bash
dotnet tool install --global dotnet-ef
```

Puis, à la racine du dépôt :

```bash
dotnet restore
dotnet ef migrations add Initiale --project src/PyroFetes.Data --startup-project src/PyroFetes.Api
dotnet ef database update --project src/PyroFetes.Data --startup-project src/PyroFetes.Api
dotnet run --project src/PyroFetes.Api
```

Swagger est ensuite disponible sur `https://localhost:<port>/swagger`.
La chaîne de connexion se trouve dans `src/PyroFetes.Api/appsettings.Development.json`.

> La migration initiale n'est pas encore créée : attendez que le diagramme de classes commun
> soit validé avec les autres groupes, puis une seule personne la génère et la pousse.

## Tests

```bash
dotnet test
```

Le workflow GitHub Actions (`.github/workflows/dotnet.yml`) compile et teste chaque push et chaque Pull Request.

## Organisation Git

- `main` : version stable et démontrable
- `develop` : intégration
- `feature/GDP-<n>-description` : une branche par ticket Jira (ex. `feature/GDP-10-generation-auto`)
- Messages de commit avec la clé Jira : `feat(GDP-10): génération automatique des bons de commande`
- Fusion dans `develop` uniquement par Pull Request relue par un autre membre
- Une seule personne crée les migrations EF à la fois

## Conventions

- Commentaires XML `///` sur toutes les classes et méthodes publiques
- Les contrôleurs passent toujours par un service, jamais directement par le `DbContext` pour la logique métier
- Aucun mot de passe dans le dépôt
