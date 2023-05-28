using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIS.Models
{
    public class Libros_has_autores
    {
        [ForeignKey("Autores_IdAutor")]
        public int Autores_IdAutor { get; set; }
        [ForeignKey("Libros_LibroId")]
        public int Libros_LibroId { get; set; }
    }
}
