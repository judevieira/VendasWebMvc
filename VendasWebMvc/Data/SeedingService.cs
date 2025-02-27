using VendasWebMvc.Models;

namespace VendasWebMvc.Data
{
    public class SeedingService
    {
        private VendasWebMvcContext _context;
        public SeedingService(VendasWebMvcContext context)
        {
            _context = context;
        }

        public void PopularBanco()
        {
            Console.WriteLine("Executando PopularBanco..."); // <-- Teste para ver se o método é chamado

            if (_context.Departamento.Any() || _context.Vendedor.Any() || _context.RegistroVendas.Any())
            {
                Console.WriteLine("Banco já está populado. Nenhuma inserção realizada.");
                return;
            }

            Departamento d1 = new Departamento(1, "Computadores");
            Departamento d2 = new Departamento(2, "Eletronicos");
            Departamento d3 = new Departamento(3, "Livros");

            Vendedor v1 = new Vendedor(1, "Elisa Matos", "elisamatos@gmail.com",
                new DateTime(1999, 4, 20), 2000.0, d1);
            Vendedor v2 = new Vendedor(2, "Daniel Vieira", "danielvieira@gmail.com",
                new DateTime(2000, 3, 10), 5000.0, d2);
            Vendedor v3 = new Vendedor(3, "Luisa Melo", "luisamelo@gmail.com",
                new DateTime(2003, 7, 6), 5000.0, d3);

            RegistroVenda rv1 = new RegistroVenda(1, new DateTime(2022, 4, 3), 15000.0,
                Models.Enums.StatusVenda.Faturado, v1);
            RegistroVenda rv2 = new RegistroVenda(2, new DateTime(2022, 4, 2), 20000.0,
                Models.Enums.StatusVenda.Pendente, v1);
            RegistroVenda rv3 = new RegistroVenda(3, new DateTime(2022, 4, 1), 30000.0,
                Models.Enums.StatusVenda.Cancelado, v1);

            _context.Departamento.AddRange(d1, d2, d3);
            _context.Vendedor.AddRange(v1, v2, v3);
            _context.RegistroVendas.AddRange(rv1, rv2, rv3);

            _context.SaveChanges();

            Console.WriteLine("Dados inseridos com sucesso!");
        }

    }
}
