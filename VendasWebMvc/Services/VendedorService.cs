using Microsoft.EntityFrameworkCore;
using VendasWebMvc.Data;
using VendasWebMvc.Models;
using VendasWebMvc.Services.Exceptions;

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
            return _context.Vendedor.Include(obj => obj.Departamento).FirstOrDefault(vendedor => vendedor.Id == id);
        }

        public void Remover(int id)
        {
            var objeto = _context.Vendedor.Find(id);
            _context.Vendedor.Remove(objeto);
            _context.SaveChanges();
        }

        public void Editar(Vendedor vendedor)
        {
            if (!_context.Vendedor.Any(x => x.Id == vendedor.Id))
            {
                throw new NotFoundException("ID não encontrado!");
            }
            try
            {
                _context.Update(vendedor);
                _context.SaveChanges();
            }
            catch(DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
            
        }
    }
}
