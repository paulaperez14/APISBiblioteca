using APIS.Data;
using APIS.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private readonly AppDbContext context;

        public LibrosController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<LibrosController>
        [HttpGet]
        public IEnumerable<Libros> Get()
        {
            return context.libros.ToList();
        }

        // GET api/<LibrosController>/5
        [HttpGet("{NombreLibro}")]
        public Libros Get(string NombreLibro)
        {
            return context.libros.FirstOrDefault(x => x.NombreLibro == NombreLibro);
        }

        // POST api/<LibrosController>
        [HttpPost]
        public int Post([FromBody] Libros libros)
        {
            int result = context.libros.Add(libros).Context.SaveChanges();
            return result;
        }

        // PUT api/<LibrosController>/5
        [HttpPut("{NombreLibro}")]
        public int Put(string NombreLibro, [FromBody] Libros actualizarLibro)
        {
            Libros? libroBuscado = context.libros.FirstOrDefault(x => x.NombreLibro == NombreLibro);
            if (libroBuscado == null) { return 0; }
            libroBuscado.NombreLibro = actualizarLibro?.NombreLibro;
            libroBuscado.FechaLanzamiento = (DateTime)(actualizarLibro?.FechaLanzamiento);
            libroBuscado.Edicion = actualizarLibro?.Edicion;
            libroBuscado.Editorial = actualizarLibro?.Editorial;
            libroBuscado.ISBN = actualizarLibro?.ISBN;
            libroBuscado.Imagen = actualizarLibro?.Imagen;

            int result = context.SaveChanges();

            return result;
        }

        // DELETE api/<LibrosController>/5
        [HttpDelete("{NombreLibro}")]
        public int Delete(string NombreLibro)
        {
            int response = 0;

            var eliminarLibro = context.libros.FirstOrDefault(x => x.NombreLibro == NombreLibro);

            if (eliminarLibro != null)
            {
                response = context.libros.Remove(eliminarLibro).Context.SaveChanges();
            }

            return response;
        }
    }
}
