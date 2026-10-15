using PyroFetes.Services;

namespace PyroFetes.Api.BackgroundServices;

/// <summary>
/// Tâche de fond exécutée au démarrage puis toutes les 24 heures :
/// génère les bons de commande manquants et journalise les livraisons en retard.
/// </summary>
public class ControleQuotidienService : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly ILogger<ControleQuotidienService> _logger;

    public ControleQuotidienService(IServiceScopeFactory scopeFactory, ILogger<ControleQuotidienService> logger)
    {
        _scopeFactory = scopeFactory;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                // Le DbContext est "scoped" : on crée un scope à chaque passage.
                using var scope = _scopeFactory.CreateScope();
                var appro = scope.ServiceProvider.GetRequiredService<ApprovisionnementService>();
                var livraisons = scope.ServiceProvider.GetRequiredService<LivraisonService>();

                var bons = await appro.VerifierTousLesSeuilsAsync();
                var retards = await livraisons.ListerRetardsAsync(DateTime.Now);

                _logger.LogInformation("Contrôle quotidien : {Bons} bon(s) de commande généré(s), {Retards} livraison(s) en retard.",
                    bons.Count, retards.Count);
            }
            catch (Exception ex)
            {
                // Une erreur (base indisponible, etc.) ne doit pas arrêter l'application.
                _logger.LogError(ex, "Échec du contrôle quotidien.");
            }

            await Task.Delay(TimeSpan.FromHours(24), stoppingToken);
        }
    }
}
