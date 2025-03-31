using System.ComponentModel.DataAnnotations;

namespace MyApplication.Web.Models
{
    public class ProfileViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100)]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address")]
        //[Required(ErrorMessage = "Password is required")]
        [StringLength(100, ErrorMessage = "Must be between 8 and 100 characters", MinimumLength = 8)]
        public string Password { get; set; }

        //[Required(ErrorMessage = "Password is required")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
