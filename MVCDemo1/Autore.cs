namespace MVCDemo1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Autore
    {
        public int ID { get; set; }

        [StringLength(200)]
        public string Nombre { get; set; }

        [StringLength(200)]
        public string Apellido { get; set; }

        public int? Nacionalidad { get; set; }

        public virtual Nacionalidade Nacionalidade { get; set; }
    }
}
