using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIS.Models
{
    public class Usuario_has_roles
    {
        [ForeignKey("Usuarios_UsuarioId1")]
        public int Usuarios_UsuarioId1 { get; set; }
        [ForeignKey("Roles_RolesId")]
        public int Roles_RolesId { get; set; }
    }
}
