using BlazorBiblioteca.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorBiblioteca.Context
{
    public class LibroDBContext : DbContext
    {
        //-- Inicializa la instancia de la clase DBContext --//
        public LibroDBContext(DbContextOptions<LibroDBContext> options) : base(options) 
        {
        }

        //-- Model --//
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
        }

        //-- Referencia entre clase Libro y la tabla Libros --//
        public DbSet<Libro> Libros { get; set; }
    }
}
