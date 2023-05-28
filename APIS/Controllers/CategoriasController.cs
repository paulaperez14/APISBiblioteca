using APIS.Data;
using APIS.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly AppDbContext context;

        public CategoriasController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<CategoriasController>
        [HttpGet]
        public IEnumerable<Categorias> Get()
        {
            return context.categorias.ToList();
        }

        // GET api/<CategoriasController>/5
        [HttpGet("{NombreCategoria}")]
        public Categorias Get(string NombreCategoria)
        {
            return context.categorias.FirstOrDefault(x => x.NombreCategoria == NombreCategoria);
        }

        // POST api/<CategoriasController>
        [HttpPost]
        public int Post([FromBody] Categorias categorias)
        {
            int result = context.categorias.Add(categorias).Context.SaveChanges();
            return result;
        }

        // PUT api/<CategoriasController>/5
        [HttpPut("{NombreCategoria}")]
        public int Put(string NombreCategoria, [FromBody] Categorias actualizarCategoria)
        {
            Categorias? categoriaBuscada = context.categorias.FirstOrDefault(x => x.NombreCategoria == NombreCategoria);
            if (categoriaBuscada == null) { return 0; }
            categoriaBuscada.NombreCategoria = actualizarCategoria?.NombreCategoria;

            int result = context.SaveChanges();

            return result;
        }

        // DELETE api/<CategoriasController>/5
        [HttpDelete("{NombreCategoria}")]
        public int Delete(string NombreCategoria)
        {
            int response = 0;

            var eliminarCategoria = context.categorias.FirstOrDefault(x => x.NombreCategoria == NombreCategoria);

            if (eliminarCategoria != null)
            {
                response = context.categorias.Remove(eliminarCategoria).Context.SaveChanges();
            }

            return response;
        }
    }
}
