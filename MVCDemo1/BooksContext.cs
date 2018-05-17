namespace MVCDemo1
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BooksContext : DbContext
    {
        public BooksContext()
            : base("name=BooksContext")
        {
        }

        public virtual DbSet<Autore> Autores { get; set; }
        public virtual DbSet<Editora> Editoras { get; set; }
        public virtual DbSet<Libro> Libros { get; set; }
        public virtual DbSet<Nacionalidade> Nacionalidades { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autore>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Autore>()
                .Property(e => e.Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Editora>()
                .Property(e => e.Editorial)
                .IsUnicode(false);

            modelBuilder.Entity<Editora>()
                .HasMany(e => e.Libros)
                .WithOptional(e => e.Editora1)
                .HasForeignKey(e => e.Editora);

            modelBuilder.Entity<Libro>()
                .Property(e => e.ISBN)
                .IsUnicode(false);

            modelBuilder.Entity<Libro>()
                .Property(e => e.Titulo)
                .IsUnicode(false);

            modelBuilder.Entity<Nacionalidade>()
                .Property(e => e.Nacionalidad)
                .IsUnicode(false);

            modelBuilder.Entity<Nacionalidade>()
                .HasMany(e => e.Autores)
                .WithOptional(e => e.Nacionalidade)
                .HasForeignKey(e => e.Nacionalidad);
        }
    }
}
