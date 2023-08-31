using System.ComponentModel.DataAnnotations;

namespace DotNetCoreBoilerplate.Identity.ViewModels
{
    public class PasswordResetViewModel
    {
        public string ApplilicationUserId { get; set; }

        public string OldPassword { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string Code { get; set; }
        public string ErrorMessage { get; set; }

    }
}
