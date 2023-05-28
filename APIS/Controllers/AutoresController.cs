using APIS.Data;
using APIS.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        private readonly AppDbContext context;

        public AutoresController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<AutoresController>
        [HttpGet]
        public IEnumerable<Autores> Get()
        {
            return context.autores.ToList();
        }

        // GET api/<AutoresController>/5
        [HttpGet("{NombreAutor}")]
        public Autores Get(string NombreAutor)
        {
            return context.autores.FirstOrDefault(x => x.NombreAutor == NombreAutor);
        }

        // POST api/<AutoresController>
        [HttpPost]
        public int Post([FromBody] Autores autores)
        {
            int result = context.autores.Add(autores).Context.SaveChanges();
            return result;
        }

        // PUT api/<AutoresController>/5
        [HttpPut("{NombreAutor}")]
        public int Put(string NombreAutor, [FromBody] Autores actualizarAutor)
        {
            Autores? autorBuscado = context.autores.FirstOrDefault(x => x.NombreAutor == NombreAutor);
            if (autorBuscado == null) { return 0; }
            autorBuscado.NombreAutor = actualizarAutor?.NombreAutor;
            autorBuscado.Pais = actualizarAutor?.Pais;
            
            int result = context.SaveChanges();

            return result;
        }

        // DELETE api/<AutoresController>/5
        [HttpDelete("{NombreAutor}")]
        public int Delete(string NombreAutor)
        {
            int response = 0;

            var eliminarAutor = context.autores.FirstOrDefault(x => x.NombreAutor == NombreAutor);

            if (eliminarAutor != null)
            {
                response = context.autores.Remove(eliminarAutor).Context.SaveChanges();
            }

            return response;
        }
    }
}
