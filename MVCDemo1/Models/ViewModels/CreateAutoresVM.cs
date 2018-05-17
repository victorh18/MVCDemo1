using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo1.Models.ViewModels
{
    public class CreateAutoresVM
    {
        public Autore _autor { get; set; }
        public SelectList Nacionalidades { get; set; }
    }
}