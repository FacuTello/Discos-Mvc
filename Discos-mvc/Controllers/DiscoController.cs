using dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using negocio;

namespace Discos_mvc.Controllers
{
    public class DiscoController : Controller
    {
        private DiscoNegocio _negocio;
        private EstiloNegocio _estilos;
        private TipoEdicionNegocio _ediciones;

        public DiscoController(DiscoNegocio negocio, EstiloNegocio estilos, TipoEdicionNegocio ediciones)
        {
            _negocio = negocio;
            _estilos = estilos;
            _ediciones = ediciones;
        }

        // GET: DiscoController
        public ActionResult Index(string filtro)
        {
            
            var discos = _negocio.listar();

            if (!string.IsNullOrEmpty(filtro))
                discos = discos.FindAll(p => p.Titulo.Contains(filtro));


            return View(discos);
        }

        // GET: DiscoController/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.Estilos = new SelectList(_estilos.listar(), "Id", "Descripcion");
            ViewBag.Ediciones = new SelectList(_ediciones.listar(), "Id", "Descripcion");

            
            var lista = _negocio.listar();
            var disco = lista.Find(p => p.Id == id);
            return View(disco);
            return View();
        }

        // GET: DiscoController/Create
        public ActionResult Create()
        {
            ViewBag.Estilos = new SelectList(_estilos.listar(), "Id", "Descripcion");
            ViewBag.Ediciones = new SelectList(_ediciones.listar(), "Id", "Descripcion");
            return View();
        }

        // POST: DiscoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Disco disco)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    
                    
                    _negocio.agregar(disco);
                }
                    return RedirectToAction(nameof(Index));
                

            }
            catch
            {
                return View();
            }
        }

        // GET: DiscoController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Estilos = new SelectList(_estilos.listar(), "Id", "Descripcion");
            ViewBag.Ediciones = new SelectList(_ediciones.listar(), "Id", "Descripcion");

            
            var lista = _negocio.listar();
            var disco = lista.Find(p => p.Id == id);


            return View(disco);
        }

        // POST: DiscoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Disco disco)
        {
            try
            {
                _negocio.modificar(disco);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DiscoController/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.Estilos = new SelectList(_estilos.listar(), "Id", "Descripcion");
            ViewBag.Ediciones = new SelectList(_ediciones.listar(), "Id", "Descripcion");

            
            var lista = _negocio.listar();
            var disco = lista.Find(p => p.Id == id);
            return View(disco);
        }

        // POST: DiscoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Disco disco)
        {
            try
            {
                _negocio.eliminar(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
