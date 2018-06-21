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

            //Many-to-many relationship regarding authors and books
            //We begin with either of the entities (once selected, this is going to be our "left entity")
            modelBuilder.Entity<Libro>()
                //We tell it the "many right entities" it can have, in this case, the many Authors a book can have
                .HasMany(x => x.Autors)
                //And then in return, we define the "many original(left)" entities the related entities can have, in this case, the many books an author can have
                .WithMany(x => x.Libros)
                //And then, we defined how this relationship will be represented in the database
                .Map(x =>
                {
                    //The join table that will hold the relationships
                    x.ToTable("autoresLibros");
                    //Which is the corresponding foreign key field for the left entity
                    x.MapLeftKey("LibroID");
                    //Which is the corresponding foreign key field for the right entity
                    x.MapRightKey("AutorID");
                });
        }
    }
}
