using VendasWebMvc.Data;
using VendasWebMvc.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace VendasWebMvc.Services
{
    public class RegistroVendaService
    {
        private readonly VendasWebMvcContext _context;

        public RegistroVendaService(VendasWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<RegistroVenda>> PesquisaPorDataAsync(DateTime? minData, DateTime? maxData)
        {
            var resultado = from obj in _context.RegistroVendas select obj;
            if (minData.HasValue)
            {
                resultado = resultado.Where(x => x.Data >= minData.Value);
            }
            if (maxData.HasValue)
            {
                resultado = resultado.Where(x => x.Data <= maxData.Value);
            }

            return await resultado
                .Include(x => x.Vendedor)
                .Include(x => x.Vendedor.Departamento)
                .OrderByDescending(x => x.Data)
                .ToListAsync();

        }
    }
}
