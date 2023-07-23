using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication_Discoteca.Models.ViewModels;
using WebApplication_Discoteca.Services;

namespace WebApplication_Discoteca.Controllers
{
    public class VinilosController : Controller
    {
        // GET: VinilosController
        public ActionResult Index()
        {
            VinilosService vinilosService = new VinilosService();
            // TO DO: tengo que recuperar el listado de vinilos..

            List<ViniloViewModel> vinilosViewModel = new List<ViniloViewModel>();

            ViniloViewModel viniloViewModel1 = new ViniloViewModel();
            viniloViewModel1.Id = 1;
            viniloViewModel1.Titulo_disco = "El bum bum";
            viniloViewModel1.Nombre_artista = "La mona";
            viniloViewModel1.Ano = 1992;
            viniloViewModel1.Canciones = "1.Beso a beso, 2.el bum bum, 3.la pupera de maria";
            viniloViewModel1.Precio = 1000;
            viniloViewModel1.Estado = "Con rasgos de mojadura en la funda o caja";
            viniloViewModel1.FechaAlta = DateTime.Now;
            vinilosViewModel.Add(viniloViewModel1);

            return View(vinilosViewModel);
        }

        // GET: VinilosController/Details/5
        public ActionResult Details(int id)
        {
            VinilosService vinilosService = new VinilosService();
            // TO DO: tengo que recuperar un vinilo...

            ViniloViewModel viniloViewModel = new ViniloViewModel();
            viniloViewModel.Id = id;
            viniloViewModel.Titulo_disco = "El bum bum";
            viniloViewModel.Nombre_artista = "La mona";
            viniloViewModel.Ano = 1992;
            viniloViewModel.Canciones = "1.Beso a beso, 2.el bum bum, 3.la pupera de maria";
            viniloViewModel.Precio = 1000;
            viniloViewModel.Estado = "Con rasgos de mojadura en la funda o caja";
            viniloViewModel.FechaAlta = DateTime.Now;

            return View(viniloViewModel);
        }

        // GET: VinilosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VinilosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ViniloViewModel viniloViewModel)
        {
            if(ModelState.IsValid)
            {
                // TO DO hacer el alta en la base de datos....
                // VUELVE AL LISTADO DE RECLAMO
                return RedirectToAction(nameof(Index));
            }
            else
            {
                // HAY ALGUN ERROR DE VALIDACION.... VUELVO A MOSTRAR EL FORMULARIO
                return View();
            }
            
        }

        // GET: VinilosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VinilosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: VinilosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VinilosController/Delete/5
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
