using APIS.Data;
using APIS.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Libros_has_autoresController : ControllerBase
    {
        private readonly AppDbContext context;

        public Libros_has_autoresController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<Libros_has_autoresController>
        [HttpGet]
        public IEnumerable<Libros_has_autores> Get()
        {
            return context.libros_has_autores.ToList();
        }

        // GET api/<Libros_has_autoresController>/5
        [HttpGet("{Autores_IdAutor}")]
        public Libros_has_autores Get(int Autores_IdAutor, int Libros_LibroId)
        {
            return context.libros_has_autores.FirstOrDefault(X => X.Autores_IdAutor == Autores_IdAutor && X.Libros_LibroId == Libros_LibroId);
        }

        // POST api/<Libros_has_autoresController>
        [HttpPost]
        public int Post([FromBody] Libros_has_autores libros_has_autores)
        {
            return context.libros_has_autores.Add(libros_has_autores).Context.SaveChanges();
        }

        // PUT api/<Libros_has_autoresController>/5
        //[HttpPut("{Autores_IdAutor}")]
        //public void Put(int Autores_IdAutor, int Libros_LibroId, [FromBody] Libros_has_autores actualizarLibros_has_autores)
        //{
        //    var libros_has_autoresBuscado = context.libros_has_autores.FirstOrDefault(X => X.Autores_IdAutor == Autores_IdAutor);

        //    if (libros_has_autoresBuscado == null)
        //    {
        //        return;
        //    }

        //    libros_has_autoresBuscado.Libros_LibroId = actualizarLibros_has_autores.Libros_LibroId;

        //    context.SaveChanges();
        //}


        // DELETE api/<Libros_has_autoresController>/5
        [HttpDelete("{Autores_IdAutor}")]
        public int Delete(int Autores_IdAutor, int Libros_LibroId)
        {
            int response = 0;

            Libros_has_autores? eliminarLibros_has_autores = context.libros_has_autores.FirstOrDefault(X => X.Autores_IdAutor == Autores_IdAutor && X.Libros_LibroId == Libros_LibroId);

            if (eliminarLibros_has_autores != null)
            {
                response = context.libros_has_autores.Remove(eliminarLibros_has_autores).Context.SaveChanges();
            }
            return response;
        }
    }
}
