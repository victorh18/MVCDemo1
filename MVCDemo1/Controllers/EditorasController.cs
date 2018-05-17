using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo1.Controllers
{
    public class EditorasController : Controller
    {
        private BooksContext db = new BooksContext();
        // GET: Editoras
        public ActionResult Index()
        {

            return View(db.Editoras.ToList());
        }

        public ActionResult Create()
        {

            return View();
        }

        //Metodo de envio de informacion
        [HttpPost]
        //Para validar el envio
        [ValidateAntiForgeryToken]
        public ActionResult Create(Editora ed)
        {
            //Valido que el registro es valido
            if (ModelState.IsValid)
            {
                //Añado el registro a las editoras disponibles
                db.Editoras.Add(ed);
                //Guardo los cambios en la base de datos
                db.SaveChanges();
                //Enviame a la pagina de inicio
                return RedirectToAction("Index");
            }
            else
            {
                //Si paso algun error, vuelve a la pagina con la informacion del registro para que la comprueben
                return View(ed);
            }
        }

        //Metodo GET para la edicion
        public ActionResult Edit(int? _id)
        {

            //Busco en la base de datos el registro correspondiente
            Editora ed = db.Editoras.Find(_id);

            //Asigno la variable al view para mostrarla y que el usuario pueda modificar
            return View(ed);
        }

        ////Metodo de retorno de editar
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(Editora _editora)
        //{
        //    if (ModelState.IsValid)
        //    {
                
        //    }
        //}

    }
}