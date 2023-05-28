using System.ComponentModel.DataAnnotations;

namespace APIS.Models
{
    public class Libros
    {
        [Key]
        public int LibroId { get; set; }
        public string NombreLibro { get; set; }
        public DateTime FechaLanzamiento { get; set; }
        public string Edicion { get; set; }
        public string Editorial { get; set; }
        public int Categorias_Codigo { get; set; }
        public string ISBN { get; set; }
        public string Imagen { get; set; }
        public string Stock { get; set; }
    }
}
