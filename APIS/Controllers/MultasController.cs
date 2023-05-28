using APIS.Data;
using APIS.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MultasController : ControllerBase
    {
        private readonly AppDbContext context;

        public MultasController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<MultasController>
        [HttpGet]
        public IEnumerable<Multas> Get()
        {
            return context.multas.ToList();
        }

        // GET api/<MultasController>/5
        [HttpGet("{id}")]
        public Multas Get(int idMultas)
        {
            return context.multas.FirstOrDefault(x => x.idMultas == idMultas);
        }

        // POST api/<MultasController>
        [HttpPost]
        public int Post([FromBody] Multas multas)
        {
            int result = context.multas.Add(multas).Context.SaveChanges();
            return result;
        }

        // PUT api/<MultasController>/5
        [HttpPut("{id}")]
        public int Put(int idMultas, [FromBody] Multas actualizarMulta)
        {
            Multas? multaBuscada = context.multas.FirstOrDefault(x => x.idMultas == idMultas);
            if (multaBuscada == null) { return 0; }
            multaBuscada.MultaTipo = actualizarMulta?.MultaTipo;
            multaBuscada.Monto = (float)(actualizarMulta?.Monto);

            int result = context.SaveChanges();

            return result;
        }

        // DELETE api/<MultasController>/5
        [HttpDelete("{id}")]
        public int Delete(int idMultas)
        {
            int response = 0;

            var eliminarMulta = context.multas.FirstOrDefault(x => x.idMultas == idMultas);

            if (eliminarMulta != null)
            {
                response = context.multas.Remove(eliminarMulta).Context.SaveChanges();
            }

            return response;
        }
    }
}
