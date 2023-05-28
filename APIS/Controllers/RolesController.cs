using APIS.Data;
using APIS.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly AppDbContext context;

        public RolesController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<RolesController>
        [HttpGet]
        public IEnumerable<Roles> Get()
        {
            return context.roles.ToList();
        }

        // GET api/<RolesController>/5
        [HttpGet("{RolesId}")]
        public Roles Get(int RolesId)
        {
            return context.roles.FirstOrDefault(x => x.RolesId == RolesId);
        }

        // POST api/<RolesController>
        [HttpPost]
        public int Post([FromBody] Roles roles)
        {
            int result = context.roles.Add(roles).Context.SaveChanges();
            return result;
        }

        // PUT api/<RolesController>/5
        [HttpPut("{RolesId}")]
        public int Put(int RolesId, [FromBody] Roles actualizarRol)
        {
            Roles? rolBuscado = context.roles.FirstOrDefault(x => x.RolesId == RolesId);
            if (rolBuscado == null) { return 0; }
            rolBuscado.TipoRol = actualizarRol?.TipoRol;

            int result = context.SaveChanges();

            return result;
        }

        // DELETE api/<RolesController>/5
        [HttpDelete("{RolesId}")]
        public int Delete(int RolesId)
        {
            int response = 0;

            var eliminarRol = context.roles.FirstOrDefault(x => x.RolesId == RolesId);

            if (eliminarRol != null)
            {
                response = context.roles.Remove(eliminarRol).Context.SaveChanges();
            }

            return response;
        }
    }
}
