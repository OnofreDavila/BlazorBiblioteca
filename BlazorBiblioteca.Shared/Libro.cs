using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BlazorBiblioteca.Shared
{ 
    public class Libro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo vacio, ingresa un nombre")]
        public string? NombreLibro { get; set; } 

        [Required(ErrorMessage = "Campo vacio, ingresa un el nombre del Autor.")]
        public string? Autor { get; set; }
    
        [Required(ErrorMessage = "Campo vacio, ingresa la cantidad de paginas del libro.")]
        public int NumPaginas { get; set; }
        public DateOnly FechaPublicacion { get; set; }


        public Libro(string nombreLibro, string autor, int numPaginas, DateOnly fechaPublicacion)
        {
            NombreLibro = nombreLibro;
            Autor = autor;
            NumPaginas = numPaginas;
            FechaPublicacion = fechaPublicacion;
        }
        public Libro() { }
    }
}
