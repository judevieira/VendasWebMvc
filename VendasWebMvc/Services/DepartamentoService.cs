using VendasWebMvc.Data;
using VendasWebMvc.Models;
using System.Linq;

namespace VendasWebMvc.Services
{
    public class DepartamentoService
    {
        private readonly VendasWebMvcContext _context;

        public DepartamentoService(VendasWebMvcContext context)
        {
            _context = context;
        } 

        public List<Departamento> listaDepartamentos()
        {
            return _context.Departamento.OrderBy(x => x.Nome).ToList();
        }
    }
}
