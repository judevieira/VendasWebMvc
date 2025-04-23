using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using VendasWebMvc.Data;
using VendasWebMvc.Services;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var configuration = builder.Configuration;

// Configuração do banco de dados
services.AddDbContext<VendasWebMvcContext>(options =>
    options.UseMySql(
        configuration.GetConnectionString("VendasWebMvcContext"),
        new MySqlServerVersion(new Version(8, 0, 39)),
        builder => builder.MigrationsAssembly("VendasWebMvc"))
    );

// Registrar o SeedingService no contêiner de injeção de dependência
services.AddScoped<SeedingService>();

services.AddScoped<VendedorService>();

services.AddScoped<DepartamentoService>();

services.AddControllersWithViews();

var app = builder.Build();

var ptBr = new CultureInfo("pt-BR");
var localizationOptions = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(ptBr),
    SupportedCultures = new List<CultureInfo> { ptBr },
    SupportedUICultures = new List<CultureInfo> { ptBr }

};

// Criar um escopo e executar o seeding ao iniciar a aplicação
using (var scope = app.Services.CreateScope())
{
    var service = scope.ServiceProvider; 
    try
    {
        Console.WriteLine("Obtendo SeedingService...");
        var seedingService = service.GetRequiredService<SeedingService>();
        seedingService.PopularBanco();
        Console.WriteLine("SeedingService executado!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro ao popular o banco: {ex.Message}");
    }
}


// Configuração do pipeline HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
