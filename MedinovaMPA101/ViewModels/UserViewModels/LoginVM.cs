using System.ComponentModel.DataAnnotations;

namespace MedinovaMPA101.ViewModels.UserViewModels
{
    public class LoginVM
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, MinLength(6), DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
