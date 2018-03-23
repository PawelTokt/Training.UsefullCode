using System.ComponentModel.DataAnnotations;

namespace MobileStore.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email is missing")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is missing")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}