using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication_Discoteca.Models;
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
            List<Vinilo> vinilos = vinilosService.RecuperarListadoDeVinilos();

            List<ViniloViewModel> vinilosViewModel = new List<ViniloViewModel>();

            foreach (Vinilo v in vinilos)
            {
                vinilosViewModel.Add(new ViniloViewModel()
                {
                    Id = v.Id,
                    Titulo_disco = v.Titulo_disco,
                    Nombre_artista = v.Nombre_artista,
                    Ano = v.Ano,
                    Canciones = v.Canciones,
                    Precio = v.Precio,
                    Estado = v.Estado,
                    FechaAlta = v.FechaAlta,
                });                    
                    
            }

            return View(vinilosViewModel);
        }

        // GET: VinilosController/Details/5
        public ActionResult Details(int id)
        {
            VinilosService vinilosService = new VinilosService();
            Vinilo vinilo = vinilosService.RecuperarVinilo(id);
            ViniloViewModel viniloViewModel = new ViniloViewModel();
            viniloViewModel.Id = id;
            viniloViewModel.Titulo_disco = vinilo.Titulo_disco;
            viniloViewModel.Nombre_artista = vinilo.Nombre_artista;
            viniloViewModel.Ano = vinilo.Ano;
            viniloViewModel.Canciones = vinilo.Canciones;
            viniloViewModel.Precio = vinilo.Precio;
            viniloViewModel.Estado = vinilo.Estado;
            viniloViewModel.FechaAlta = vinilo.FechaAlta;

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
                VinilosService viniloService = new VinilosService();
                Vinilo vinilo = new Vinilo();
                vinilo.Titulo_disco = viniloViewModel.Titulo_disco;
                vinilo.Nombre_artista = viniloViewModel.Nombre_artista;
                vinilo.Ano = viniloViewModel.Ano;
                vinilo.Canciones = viniloViewModel.Canciones;
                vinilo.Precio = viniloViewModel.Precio;
                vinilo.Estado = viniloViewModel.Estado;
                vinilo.FechaAlta = DateTime.Now;

                viniloService.AltaDeVinilo(vinilo);
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
            VinilosService vinilosService = new VinilosService();
            Vinilo vinilo = vinilosService.RecuperarVinilo(id);
            ViniloViewModel viniloViewModel = new ViniloViewModel();
            viniloViewModel.Id = id;
            viniloViewModel.Titulo_disco = vinilo.Titulo_disco;
            viniloViewModel.Nombre_artista = vinilo.Nombre_artista;
            viniloViewModel.Ano = vinilo.Ano;
            viniloViewModel.Canciones = vinilo.Canciones;
            viniloViewModel.Precio = vinilo.Precio;
            viniloViewModel.Estado = vinilo.Estado;
            viniloViewModel.FechaAlta = vinilo.FechaAlta;

            return View(viniloViewModel);
        }

        // POST: VinilosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ViniloViewModel viniloViewModel)
        {
            if (ModelState.IsValid)
            {

                VinilosService vinilosService = new VinilosService();
                Vinilo vinilo = vinilosService.RecuperarVinilo(id);
                vinilo.Id = id;
                vinilo.Titulo_disco = viniloViewModel.Titulo_disco;
                vinilo.Nombre_artista = viniloViewModel.Nombre_artista;
                vinilo.Ano = viniloViewModel.Ano;
                vinilo.Canciones = viniloViewModel.Canciones;
                vinilo.Precio = viniloViewModel.Precio;
                vinilo.Estado = viniloViewModel.Estado;
                VinilosService.ActualizarVinilo(vinilo);

                return RedirectToAction(nameof(Index));
            }
            else
            {
                // HAY ALGUN ERROR DE VALIDACION.... VUELVO A MOSTRAR EL FORMULARIO
                return View();
            }
        }

        // GET: VinilosController/Delete/5
        public ActionResult Delete(int id)
        {
            // TO DO: borrar de la base de datos el reclamo
            VinilosService vinilosService = new VinilosService();
            vinilosService.BorrarVinilo(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
