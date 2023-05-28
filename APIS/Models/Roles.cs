using System.ComponentModel.DataAnnotations;

namespace APIS.Models
{
    public class Roles
    {
        [Key]
        public int RolesId { get; set; }
        public string TipoRol { get; set; }
    }
}
