using System.ComponentModel.DataAnnotations;

namespace APIS.Models
{
    public class Prestamo_libros
    {
        [Key]
        public int idPrestamoLibros { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaEntrega { get; set; }
        public bool EntregaAtrasada { get; set; }
        public float Usuarios_UsuarioId { get; set; }
        public int Libros_LibroId { get; set; }
    }
}
