using System.ComponentModel.DataAnnotations;

namespace MyApplication.Web.Models
{
    public class JoinInvitationViewModel
    {
        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, ErrorMessage = "Must be between 8 and 100 characters", MinimumLength = 8)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password is required")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string CompanyName { get; set; }
    }
}
