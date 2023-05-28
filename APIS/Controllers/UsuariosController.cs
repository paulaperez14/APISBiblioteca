using APIS.Data;
using APIS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly AppDbContext context;

        public UsuariosController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<UsuariosController>
        [HttpGet]
        public IEnumerable<Usuarios> Get()
        {
            return context.usuarios.ToList();
        }

        // GET api/<UsuariosController>/5
        [HttpGet("{IdentificacionNum}")]
        public Usuarios Get(string IdentificacionNum)
        {
            return context.usuarios.FirstOrDefault(x => x.IdentificacionNum == IdentificacionNum);
        }

        // POST api/<UsuariosController>
        [HttpPost]
        public int Post([FromBody] Usuarios usuario)
        {
            int result = context.usuarios.Add(usuario).Context.SaveChanges();
            return result;
        }

        // PUT api/<UsuariosController>/5
        [HttpPut("{IdentificacionNum}")]
        public int Put(string IdentificacionNum, [FromBody] Usuarios actualizarUsuario)
        {
            Usuarios? usuarioBuscado = context.usuarios.FirstOrDefault(x => x.IdentificacionNum == IdentificacionNum);
            if (usuarioBuscado == null) { return 0; }
            usuarioBuscado.TipoIdentificacion = actualizarUsuario?.TipoIdentificacion;
            usuarioBuscado.IdentificacionNum = actualizarUsuario?.IdentificacionNum;
            usuarioBuscado.Contrasena = actualizarUsuario?.Contrasena;
            usuarioBuscado.Nombres = actualizarUsuario?.Nombres;
            usuarioBuscado.Apellidos = actualizarUsuario?.Apellidos;
            usuarioBuscado.FechaNacimiento = (DateTime)(actualizarUsuario?.FechaNacimiento);
            usuarioBuscado.Telefono = actualizarUsuario?.Telefono;
            usuarioBuscado.TipoSangre = actualizarUsuario?.TipoSangre;
            usuarioBuscado.Direccion = actualizarUsuario?.Direccion;
            usuarioBuscado.Semestre = actualizarUsuario?.Semestre;
            usuarioBuscado.Carrera = actualizarUsuario?.Carrera;
            usuarioBuscado.Imagen = actualizarUsuario?.Imagen;

            int result = context.SaveChanges();

            return result;
        }

        // DELETE api/<UsuariosController>/5
        [HttpDelete("{IdentificacionNum}")]
        public int Delete(string IdentificacionNum)
        {
            int response = 0;

            var eliminarUsuario = context.usuarios.FirstOrDefault(x => x.IdentificacionNum == IdentificacionNum);

            if (eliminarUsuario != null)
            {
                response = context.usuarios.Remove(eliminarUsuario).Context.SaveChanges();
            }

            return response;
        }
    }
}
