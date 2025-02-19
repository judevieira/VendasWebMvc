using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using VendasWebMvc.Data;

var builder = WebApplication.CreateBuilder(args);

// ?? Criamos um alias para services e configuration
var services = builder.Services;
var configuration = builder.Configuration;

services.AddDbContext<VendasWebMvcContext>(options =>
    options.UseMySql(
        configuration.GetConnectionString("VendasWebMvcContext"),
        new MySqlServerVersion(new Version(8, 0, 39)),
        builder => builder.MigrationsAssembly("VendasWebMvc"))
    );

// Adicionar serviços ao contêiner
services.AddControllersWithViews();

var app = builder.Build();

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
