using System;
using System.ComponentModel.DataAnnotations;

namespace MyApplication.Core.Model.User
{
    public class AppUserListModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public int CompanyId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? StartBreak { get; set; }
        public DateTime? EndBreak { get; set; }
        public string WorkTime { get; set; }
        public string BreakTime { get; set; }
        public int TaskId { get; set; }
        public bool IsLoggedin { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public bool IsCurrentUser { get; set; }
    }
    public class CreateTeamModel
    {
        public string Id { get; set; }
        public string TeamName { get; set; }
        public string UserId { get; set; }
    }


    public class AppUserAddModel
    {
        public string Id { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$^+=!*()@%&]).{8,}$", ErrorMessage = "Password must have minimum 8 characters and contain 1 uppercase letter, 1 lowercase letter, 1 digit and 1 special character.")]
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and confirmation password not match.")]
        [Required(ErrorMessage = "Confirm password is required.")]
        public string ConfirmPassword { get; set; }
        public bool IsEmailConfirmed { get; set; }
    }

    public class AppUserEditModel
    {
        public string Id { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
        [Display(Name = "New Password")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$^+=!*()@%&]).{8,}$", ErrorMessage = "Password must have minimum 8 characters and contain 1 uppercase letter, 1 lowercase letter, 1 digit and 1 special character.")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [Display(Name = "Confirm Password")]
        [Compare("NewPassword", ErrorMessage = "Password and confirmation password not match.")]
        public string ConfirmPassword { get; set; }
        public bool IsEmailConfirmed { get; set; }
    }

    public class AddTeamModel
    {
        public string Id { get; set; }

        [Display(Name = "Team Name")]
        [Required(ErrorMessage = "Team name is required.")]
        public string TeamName { get; set;}

        public string UserId { get; set; }
    }
}
