using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCDemo1;
using PagedList;
using System.Text.RegularExpressions;
using MVCDemo1.Models.ViewModels;

namespace MVCDemo1.Controllers
{
    public class LibrosController : Controller
    {
        private BooksContext db = new BooksContext();

        // GET: Libros
        public ActionResult Index()
        {
            var libros = db.Libros.Include(l => l.Editora1);

            List<ListBookVM> librosVista = new List<ListBookVM>();

            foreach (var lib in libros)
            {
                librosVista.Add(new ListBookVM { libro = lib });

            }

            //return View(libros.ToList());
            return View(librosVista.ToList());

        }
       
        // GET: Libros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libro libro = db.Libros.Find(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            return View(libro);
        }

        // GET: Libros/Create
        public ActionResult Create()
        {
            ViewBag.phoneMask = "999-999-9999";
            ViewBag.Editora = new SelectList(db.Editoras, "ID", "Editorial");
            return View();
        }

        // POST: Libros/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(/*[Bind(Include = "ID,ISBN,Titulo,FechaPublicacion,Cantidad,Editora,Cantidad_Paginas")]*/ Libro libro)
        {
            if (ModelState.IsValid)
            {
                libro.ISBN = Regex.Replace(libro.ISBN, @"[^0-9]", "");
                db.Libros.Add(libro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Editora = new SelectList(db.Editoras, "ID", "Editorial", libro.Editora);

            return View(libro);
        }
        
        // GET: Libros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libro libro = db.Libros.Find(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            ViewBag.Editora = new SelectList(db.Editoras, "ID", "Editorial", libro.Editora);
            //To allow selecting multiple authors
            //First, the complete list of available authors, with the complete name
            var authors = db.Autores.AsEnumerable()
                .Select(a => new
                {
                    AuthorID = a.ID,
                    Name = string.Format("{0} {1}", a.Nombre, a.Apellido)
                    //Name = $"{a.Nombre} {a.Apellido}"
                });
                //.ToList();
            ViewBag.Autores = new SelectList(authors, "AuthorID", "Name");
            //ViewBag.Autores = new SelectList(authors, nameof(Autore.Nombre), nameof(Autore.Nombre);

            return View(libro);
        }

        // POST: Libros/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ISBN,Titulo,FechaPublicacion,Cantidad,Editora,Cantidad,Cantidad_Paginas")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(libro).State = EntityState.Modified;
                db.SaveChanges();
                //return RedirectToAction("Index");
                return Content("<script>alert('Actualizado correctamente');\nwindow.location.href = \"/Libros\"</script>");
            }
            ViewBag.Editora = new SelectList(db.Editoras, "ID", "Editorial", libro.Editora);
            return View(libro);
        }

        // GET: Libros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libro libro = db.Libros.Find(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            //return View(libro);
            string retorno = "<script>var result = confirm(\"¿Estas seguro de que deseas borrar el libro " + libro.Titulo + "?\");" + /*"</script>";*/
            "if (result == true) {\n" +
            "window.location.href = \"/Libros/DeleteConfirmed/" + libro.ID + "\";\n" +
            "} else {" +
            "window.location.href = \"/Libros\"" +
            "}" +
            "</script>";
            return Content(retorno);
        }

        // POST: Libros/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Libro libro = db.Libros.Find(id);
            db.Libros.Remove(libro);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
