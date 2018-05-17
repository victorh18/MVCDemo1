using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo1.Controllers
{
    /*
     THINGS TO DO:
        -Add partial view for the context of each controller(entity), where it groups the possible actions for them(create, etc), and share the same color
        -Figure out how to represent many to many relationships when creating new entities
        -Stylize it with some standard
        -A control for date
        -A way to delete masively
         */

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}