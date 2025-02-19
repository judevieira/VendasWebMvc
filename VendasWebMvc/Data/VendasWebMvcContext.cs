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

        // DbSet representando a tabela "Departamento" no banco de dados
        public DbSet<Departamento> Departamento { get; set; } = default!;
    }
}
