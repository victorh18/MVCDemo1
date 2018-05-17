namespace MVCDemo1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Libros")]
    public partial class Libro
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string ISBN { get; set; }

        [StringLength(1000)]
        public string Titulo { get; set; }

        [Display(Name = "Fecha de publicación")]
        [Column(TypeName = "date")]
        public DateTime? FechaPublicacion { get; set; }

        public int? Cantidad { get; set; }

        public int? Editora { get; set; }

        [Column("CantidadPaginas")]
        [Display(Name = "Cantidad de páginas")]
        public int? Cantidad_Paginas { get; set; }

        public virtual Editora Editora1 { get; set; }
    }
}
