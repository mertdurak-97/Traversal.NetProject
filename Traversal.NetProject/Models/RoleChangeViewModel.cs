using System.ComponentModel.DataAnnotations;

namespace Traversal.NetProject.Models
{
    public class RoleChangeViewModel
    {
        [Required(ErrorMessage = "Lütfen Rol Adını Giriniz !")]
        public string? name { get; set; }
    }
}
