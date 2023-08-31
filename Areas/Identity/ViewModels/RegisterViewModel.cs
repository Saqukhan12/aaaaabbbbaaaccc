using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DotNetCoreBoilerplate.Common.BaseEntity;

namespace DotNetCoreBoilerplate.Identity.ViewModels
{
    public class RegisterViewModel
    {
        public string ApplicationUserID { get; set; }
        public string ReturnUrl { get; set; }
        [Required]
        [DisplayName("Username")]
        public string UserName { get; set; }
        [DisplayName("User Email")]
        public string Email { get; set; }
        public string AvatarURL { get; set; }
        [DisplayName("Mobile Number")]
        public string MobileNumber { get; set; }
        [DisplayName("Profile Image")]
        public string ProfileImage { get; set; }

        [MaxLength(128)]

        [NotMapped]
        public string RoleName { get; set; }

        [DisplayName("User Stamp")]
        public string UserStamp { get; set; }
        public string Role { get; set; }
        public bool IsOnline { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public string LastName { get; set; }
        public int LoginCount { get; set; }
        public string FirstName { get; set; }
        public string FullName => $"{this.FirstName} {this.LastName}";

        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        public IEnumerable<GUBaseSelectList> RoleList { get; set; }
    }
}

