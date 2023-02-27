using System.ComponentModel.DataAnnotations;

namespace Traversal.NetProject.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage = "Lütfen Kullanıcı Adını Giriniz")]
        public string? username { get; set; }

        [Required(ErrorMessage = "Lütfen Şifrenizi Giriniz")]
        public string? password { get; set; }
    }
}
