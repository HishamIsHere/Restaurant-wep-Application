using System.ComponentModel.DataAnnotations;

namespace WebAppTemplate.ViewModels
{
    //Data Annotations
    public class RegisterViewModel
    {
        // UserName / Email/ Password

        public string Username { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password is not matching")]
        public string ConfirmPassword { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
