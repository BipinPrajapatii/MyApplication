using System.ComponentModel.DataAnnotations;

namespace MyApplication.Web.Models
{
    public class ForgotPasswordViewModel
    {
        [Required]
        public string Email { get; set; }
    }


}
