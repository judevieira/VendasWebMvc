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

        public Vendedor EncontrePorId(int id)
        {
            return _context.Vendedor.FirstOrDefault(vendedor => vendedor.Id == id);
        }

        public void Remover(int id) 
        {
            var objeto = _context.Vendedor.Find(id);
            _context.Vendedor.Remove(objeto);
            _context.SaveChanges();
        }
    }
}
