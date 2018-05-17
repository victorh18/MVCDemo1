using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDemo1.Models.ViewModels;

namespace MVCDemo1.Controllers
{
    public class AutoresController : Controller
    {
        //Creo la variable que va a manejar la interaccion con la base de datos
        private BooksContext db = new BooksContext();
        // GET: Autores
        public ActionResult Index()
        {
            //Muestro todos los autores registrados actualmente
            return View(db.Autores.ToList());
        }

        //Metodo GET para que me lleve a la pagina para registrar Autores
        public ActionResult Create()
        {
            //Preparo la lista con los campos que quiero mostrar en el dropdownlist y el qeu quiero considerar como key
            var listaNacionalidades = from n in db.Nacionalidades
                                      select new { n.ID, n.Nacionalidad };

            //Cargo una lista con las nacionalidades para poder seleccionarlas en la pagina
            CreateAutoresVM _viewModel = new CreateAutoresVM();

            //Asigno las nacionalidades al modelo que voy a utilizar en la vista
            _viewModel.Nacionalidades = new SelectList(listaNacionalidades.ToList(), "ID", "Nacionalidad");

            return View(_viewModel);
        }

        //Metodo HttpPost para recibir la info del Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateAutoresVM _viewModel)
        {
            //Chequeamos el estado del modelo
            if (ModelState.IsValid)
            {
                //Agregamos el registro a los autores existentes
                db.Autores.Add(_viewModel._autor);
                //Guardamos los datos
                db.SaveChanges();
                //Mandamos al usuario a la lista
                return RedirectToAction("Index");

            }
            else
            {
                //Si algo salio mal, lo devolvemos 
                return View(_viewModel);
            }
        }

        public ActionResult Nacionalidades()
        {
            return RedirectToAction("Index", "Nacionalidades");
        }
    }
}