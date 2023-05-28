using System.ComponentModel.DataAnnotations;

namespace APIS.Models
{
    public class Multas
    {
        [Key]
        public int idMultas { get; set; }
        public DateTime FechaMulta { get; set;}
        public string MultaTipo { get; set;}
        public float Monto { get; set;}
        public int Prestamo_Libros_idPrestamoLibros { get; set;}
        public int Prestamo_Libros_Usuarios_UsuarioId { get; set;}
        public int Prestamo_Libros_Libros_LibroId { get; set;}
    }
}
