using System.ComponentModel.DataAnnotations;

namespace Traversal.NetProject.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Lütfen Adınızı Giriniz")]
        public string? Name { get; set; }


        [Required(ErrorMessage = "Lütfen Soyadınızı Giriniz")]
        public string? Surname { get; set; }


        [Required(ErrorMessage = "Lütfen Kullanıcı Adınızı Giriniz")]
        public string? UserName { get; set; }


        [Required(ErrorMessage = "Lütfen Mail Adresinizi Giriniz")]
        public string? Mail { get; set; }


        [Required(ErrorMessage = "Lütfen Şifrenizi Giriniz")]
        public string? Password { get; set; }


        [Required(ErrorMessage = "Lütfen Aynı Şİfreyi Giriniz")]
        [Compare("Password", ErrorMessage = "Şifreler Uyuşmuyor !")]
        public string? ConfirmPassword { get; set; }


    }
}
