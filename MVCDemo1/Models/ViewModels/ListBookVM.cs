using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDemo1.Models.ViewModels
{
    public class ListBookVM
    {
        public Libro libro { get; set; }
        public string ISBNFormatter { get {
                string lol = libro.ISBN;
                lol = lol.PadLeft(10);
                return lol.Substring(1, 3) + "-" + lol.Substring(4, 3) + "-" + lol.Substring(6, 4);
            }
        }
    }
}