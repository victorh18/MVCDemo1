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
        [DisplayFormat(DataFormatString = "{0:###-#####-#}")]
        public string ISBN { get; set; }

        [StringLength(1000)]
        public string Titulo { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de publicación")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "date")]
        public DateTime? FechaPublicacion { get; set; }

        public int? Cantidad { get; set; }

        public int? Editora { get; set; }

        [Column("CantidadPaginas")]
        [Display(Name = "Cantidad de páginas")]
        public int? Cantidad_Paginas { get; set; }

        public virtual Editora Editora1 { get; set; }

        //For the many-to-many relationship regarding Authors
        public virtual ICollection<Autore> Autors { get; set; }

        //public Libro()
        //{
        //    Autors = new List<Autore>();
        //}
    }
}
