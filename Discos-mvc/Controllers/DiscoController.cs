using dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using negocio;

namespace Discos_mvc.Controllers
{
    public class DiscoController : Controller
    {
        // GET: DiscoController
        public ActionResult Index()
        {
            DiscoNegocio negocio = new DiscoNegocio();
            var lista = negocio.listar();
            return View(lista);
        }

        // GET: DiscoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DiscoController/Create
        public ActionResult Create()
        {
            EstiloNegocio estilos = new EstiloNegocio();
            TipoEdicionNegocio ediciones = new TipoEdicionNegocio();
            ViewBag.Estilos = new SelectList(estilos.listar(), "Id", "Descripcion");
            ViewBag.Ediciones = new SelectList(ediciones.listar(), "Id", "Descripcion");
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
                    DiscoNegocio negocio = new DiscoNegocio();
                    
                    negocio.agregar(disco);
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

            EstiloNegocio estilos = new EstiloNegocio();
            TipoEdicionNegocio ediciones = new TipoEdicionNegocio();
            ViewBag.Estilos = new SelectList(estilos.listar(), "Id", "Descripcion");
            ViewBag.Ediciones = new SelectList(ediciones.listar(), "Id", "Descripcion");

            DiscoNegocio negocio = new DiscoNegocio();
            var lista = negocio.listar();
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
                DiscoNegocio negocio = new DiscoNegocio();
                negocio.modificar(disco);

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
            return View();
        }

        // POST: DiscoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
