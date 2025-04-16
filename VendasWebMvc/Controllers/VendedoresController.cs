using Microsoft.AspNetCore.Mvc;
using VendasWebMvc.Models;
using VendasWebMvc.Models.ViewModels;
using VendasWebMvc.Services;
using VendasWebMvc.Services.Exceptions;

namespace VendasWebMvc.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly VendedorService _vendedorService;
        private readonly DepartamentoService _departamentoService;

        public VendedoresController(VendedorService vendedorService, DepartamentoService departamentoService) //acessa service
        {
            _vendedorService = vendedorService;
            _departamentoService = departamentoService;
        }

        //IActionResult resultado de uma ação (um método) em um controller
        public IActionResult Index()
        {
            var list = _vendedorService.EncontreTodos();
            return View(list);
        }

        public IActionResult Criar()
        {
            var departamentos = _departamentoService.listaDepartamentos();
            var viewModel = new FormVendedorViewModel { Departamentos = departamentos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Criar(Vendedor vendedor)
        {
            _vendedorService.Insert(vendedor);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var objeto = _vendedorService.EncontrePorId(id.Value); //value pq é opcional
            if(objeto == null)
            {
                return NotFound();
            }
            
            return View(objeto);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _vendedorService.Remover(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detalhes(int? id)
        {
            if(id == null){
                return NotFound();
            }

            var objeto = _vendedorService.EncontrePorId(id.Value);
            if(objeto == null)
            {
                return NotFound();
            }

            return View(objeto);
        }
        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var objeto = _vendedorService.EncontrePorId(id.Value);

            if (objeto == null)
            {
                return NotFound();
            }

            List<Departamento> departamentos = _departamentoService.listaDepartamentos();
            FormVendedorViewModel viewModel = new FormVendedorViewModel { Vendedor = objeto, Departamentos = departamentos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(int id, Vendedor vendedor)
        {
            if (id != vendedor.Id)
            {
                return BadRequest();
            }

            try
            {
                _vendedorService.Editar(vendedor);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (DbConcurrencyException)
            {
                return BadRequest();
            }


        }
    }
}
