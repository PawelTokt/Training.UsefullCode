using System.ComponentModel.DataAnnotations;

namespace MobileStore.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Email is missing")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is missing")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password entered incorrectly")]
        public string ConfirmPassword { get; set; }
    }
}