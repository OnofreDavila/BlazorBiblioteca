using BlazorBiblioteca.Context;
using BlazorBiblioteca.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorBiblioteca.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        //-- Inicializar context --//
        private readonly LibroDBContext _context;

        public LibroController(LibroDBContext context) 
        {
            _context = context;
        }

        //--  Peticion Http Get que conecta la tabla Libros --//
        [HttpGet("ConexionLibros")]
        public async Task<ActionResult<string>> GetConexionUsuarios()
        {
            try
            {
                var repuesta = await _context.Libros.ToListAsync();
                return "conectado a la base de datos y a la tabla Libros";
            }
            catch (Exception ex)
            {
                return "Error de conexion con Libros";
            }
        }

        //-- Peticion Http Get que conecta con el servidor --//
        [HttpGet("ConexionServidor")]
        public async Task <ActionResult<string>> Conexion()
        {
            return "conectado con el servidor";
        }

        //-- Listar Libros --//
        [HttpGet("LibrosListar")]
        public async Task<ActionResult<List<Libro>>> ListarLibros()
        {
            var res = await _context.Libros.ToListAsync();
            return res;
        }

        //-- Agregar Libros --//
        [HttpPost("LibroAgregar")]
        public async Task<ActionResult<string>> HandleCreateLibro([FromBody] Libro libro)
        {    
            
            await _context.Libros.AddAsync(libro);
            var res = await _context.SaveChangesAsync();

            if (res == 1) return Created("", libro);
            else return BadRequest();
        }

        //-- Actualizar libro --//
        [HttpPut("libro/{id}")]
        public async Task<ActionResult<string>> ActualizarPelicula(int id, Libro libro)
        {
            var find = await _context.Libros.FindAsync(id);

            if (find == null) return NotFound();

            var res = await _context.Libros
                .Where(x => x.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(p => p.NombreLibro, libro.NombreLibro)
                    .SetProperty(p => p.Autor, libro.Autor)
                    .SetProperty(p => p.NumPaginas, libro.NumPaginas)
                    .SetProperty(p => p.FechaPublicacion, libro.FechaPublicacion));
            if (res == 1) return Ok();
            else return BadRequest();
        }

        //-- Eliminar Libro--//
        [HttpDelete("libro/{id}")]
        public async Task<ActionResult<string>> HandleDeleteLibro([FromRoute] int id)
        {
            var find = await _context.Libros.Where(x => x.Id == id).ExecuteDeleteAsync();

            if (find == 1) return Ok();
            else return BadRequest();
        }

    }
}
