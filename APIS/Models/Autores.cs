using System.ComponentModel.DataAnnotations;

namespace APIS.Models
{
    public class Autores
    {
        [Key]
        public int IdAutor { get; set; }
        public string NombreAutor { get; set;}
        public string Pais { get; set; }
    }
}
