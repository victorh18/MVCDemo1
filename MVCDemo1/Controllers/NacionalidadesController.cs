using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo1.Controllers
{
    public class NacionalidadesController : Controller
    {
        //Variable que me maneja la interaccion con la bd
        private BooksContext db = new BooksContext();
        // GET: Nacionalidades
        public ActionResult Index()
        {
            return View(db.Nacionalidades.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Nacionalidade _nacionalidad)
        {
            if (ModelState.IsValid)
            {
                db.Nacionalidades.Add(_nacionalidad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }else
            {
                return View(_nacionalidad);
            }
        }
    }
}