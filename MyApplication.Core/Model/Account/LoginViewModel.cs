using System.ComponentModel.DataAnnotations;

namespace MyApplication.Core.Model.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email is required.")]
        [Display(Name ="Email")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage= "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
