using APIS.Data;
using APIS.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Prestamo_librosController : ControllerBase
    {
        private readonly AppDbContext context;

        public Prestamo_librosController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<Prestamo_librosController>
        [HttpGet]
        public IEnumerable<Prestamo_libros> Get()
        {
            return context.prestamo_libros.ToList();
        }

        // GET api/<Prestamo_librosController>/5
        [HttpGet("{idPrestamoLibros}")]
        public Prestamo_libros Get(int idPrestamoLibros)
        {
            return context.prestamo_libros.FirstOrDefault(x => x.idPrestamoLibros == idPrestamoLibros);
        }

        // POST api/<Prestamo_librosController>
        [HttpPost]
        public int Post([FromBody] Prestamo_libros prestamo_libros)
        {
            int result = context.prestamo_libros.Add(prestamo_libros).Context.SaveChanges();
            return result;
        }

        // PUT api/<Prestamo_librosController>/5
        [HttpPut("{idPrestamoLibros}")]
        public int Put(int idPrestamoLibros, [FromBody] Prestamo_libros actualizarPrestamo_Libro)
        {
            Prestamo_libros? prestamoBuscado = context.prestamo_libros.FirstOrDefault(x => x.idPrestamoLibros == idPrestamoLibros);
            if (prestamoBuscado == null) { return 0; }
            prestamoBuscado.FechaPrestamo = (DateTime)(actualizarPrestamo_Libro?.FechaPrestamo);
            prestamoBuscado.FechaEntrega = (DateTime)(actualizarPrestamo_Libro?.FechaEntrega);
            prestamoBuscado.EntregaAtrasada = (bool)(actualizarPrestamo_Libro?.EntregaAtrasada);

            int result = context.SaveChanges();

            return result;
        }

        // DELETE api/<Prestamo_librosController>/5
        [HttpDelete("{idPrestamoLibros}")]
        public int Delete(int idPrestamoLibros)
        {
            int response = 0;

            var eliminarPrestamo_libro = context.prestamo_libros.FirstOrDefault(x => x.idPrestamoLibros == idPrestamoLibros);

            if (eliminarPrestamo_libro != null)
            {
                response = context.prestamo_libros.Remove(eliminarPrestamo_libro).Context.SaveChanges();
            }

            return response;
        }
    }
}
