using System.ComponentModel.DataAnnotations;

namespace APIS.Models
{
    public class Usuarios
    {
        [Key]
        public int UsuarioId { get; set; }
        public string TipoIdentificacion { get; set; }
        public string IdentificacionNum { get; set; }
        [DataType(DataType.Password)]
        public string Contrasena { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string TipoSangre { get; set; }
        public string Direccion { get; set;}
        public string Correo { get; set;}
        public string Semestre { get; set; }
        public string Carrera { get; set; }
        public string Imagen { get; set; }

    }
}
