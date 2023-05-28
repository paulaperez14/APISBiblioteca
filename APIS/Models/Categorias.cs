using System.ComponentModel.DataAnnotations;

namespace APIS.Models
{
    public class Categorias
    {
        [Key]
        public int Codigo { get; set; }
        public string NombreCategoria { get; set; }
    }
}
