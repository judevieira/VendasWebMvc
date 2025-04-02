using VendasWebMvc.Data;
using VendasWebMvc.Models;

namespace VendasWebMvc.Services
{
    public class VendedorService
    {
        //dependencia para VendasWebMvcContext, acessa banco
        private readonly VendasWebMvcContext _context;

        public VendedorService(VendasWebMvcContext context)
        {
            _context = context;
        }

        public List<Vendedor> EncontreTodos()
        {
            return _context.Vendedor.ToList();
        }

        public void Insert(Vendedor vendedor)
        {
            _context.Add(vendedor);
            _context.SaveChanges();
        } 
    }
}
