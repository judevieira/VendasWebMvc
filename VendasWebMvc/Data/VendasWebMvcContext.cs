using Microsoft.EntityFrameworkCore;
using VendasWebMvc.Models;

namespace VendasWebMvc.Data
{
    public class VendasWebMvcContext : DbContext
    {
        public VendasWebMvcContext(DbContextOptions<VendasWebMvcContext> options)
            : base(options)
        {
        }

        // DbSet representando as tabelas no banco de dados
        public DbSet<Departamento> Departamento { get; set; } = default!;
        public DbSet<Vendedor> Vendedor { get; set; } = default!;
        public DbSet<RegistroVenda> RegistroVendas { get; set; } = default!;
    }
}
