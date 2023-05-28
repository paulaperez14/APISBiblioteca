using APIS.Data;
using APIS.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Usuario_has_rolesController : ControllerBase
    {
        private readonly AppDbContext context;

        public Usuario_has_rolesController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<Usuario_has_rolesController>
        [HttpGet]
        public IEnumerable<Usuario_has_roles> Get()
        {
            return context.usuario_has_roles.ToList();
        }

        // GET api/<Usuario_has_rolesController>/5
        [HttpGet("{Usuarios_UsuarioId1}")]
        public Usuario_has_roles Get(int Usuarios_UsuarioId1, int Roles_RolesId)
        {
            return context.usuario_has_roles.FirstOrDefault(X => X.Usuarios_UsuarioId1 == Usuarios_UsuarioId1 && X.Roles_RolesId == Roles_RolesId);
        }

        // POST api/<Usuario_has_rolesController>
        [HttpPost]
        public int Post([FromBody] Usuario_has_roles usuario_has_roles)
        {
            return context.usuario_has_roles.Add(usuario_has_roles).Context.SaveChanges();
        }

        // PUT api/<Usuario_has_rolesController>/5
        //[HttpPut("{Usuarios_UsuarioId1}")]
        //public void Put(int Usuarios_UsuarioId1, [FromBody] Usuario_has_roles actualizarUsuario_has_roles)
        //{
        //    var usuario_has_rolessBuscado = context.usuario_has_roles.FirstOrDefault(X => X.Usuarios_UsuarioId1 == Usuarios_UsuarioId1);

        //    if (usuario_has_rolessBuscado == null)
        //    {
        //        return;
        //    }

        //    // Remove the existing entity
        //    context.usuario_has_roles.Remove(usuario_has_rolessBuscado);

        //    // Create a new entity with the updated relationship
        //    var nuevoUsuario_has_roles = new Usuario_has_roles
        //    {
        //        Usuarios_UsuarioId1 = actualizarUsuario_has_roles.Usuarios_UsuarioId1,
        //        Roles_RolesId = actualizarUsuario_has_roles.Roles_RolesId
        //    };

        //    // Add the new entity to the context
        //    context.usuario_has_roles.Add(nuevoUsuario_has_roles);

        //    context.SaveChanges();
        //}

        // DELETE api/<Usuario_has_rolesController>/5
        [HttpDelete("{Usuarios_UsuarioId1}")]
        public int Delete(int Usuarios_UsuarioId1, int Roles_RolesId)
        {
            int response = 0;

            Usuario_has_roles? eliminarUsuario_has_roles = context.usuario_has_roles.FirstOrDefault(X => X.Usuarios_UsuarioId1 == Usuarios_UsuarioId1 && X.Roles_RolesId == Roles_RolesId);

            if (eliminarUsuario_has_roles != null)
            {
                response = context.usuario_has_roles.Remove(eliminarUsuario_has_roles).Context.SaveChanges();
            }
            return response;
        }
    }
}
