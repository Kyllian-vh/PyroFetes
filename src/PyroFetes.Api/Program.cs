using System.Reflection;
using Microsoft.EntityFrameworkCore;
using PyroFetes.Api.BackgroundServices;
using PyroFetes.Data;
using PyroFetes.Services;

var builder = WebApplication.CreateBuilder(args);

// Base de données : chaîne "PyroFetes" définie dans appsettings.Development.json.
builder.Services.AddDbContext<PyroFetesContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PyroFetes")));

// Services métier.
builder.Services.AddScoped<ApprovisionnementService>();
builder.Services.AddScoped<LivraisonService>();

// Contrôle quotidien des seuils de stock et des retards de livraison.
builder.Services.AddHostedService<ControleQuotidienService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    // Affiche les commentaires XML /// des contrôleurs dans Swagger.
    var xml = Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml");
    if (File.Exists(xml)) options.IncludeXmlComments(xml);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
