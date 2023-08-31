using System;
using System.ComponentModel;

namespace DotNetCoreBoilerplate.Identity.ViewModels
{
    public class UserIndexViewModel
    {
        public string ApplicationUserId { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Full Name")]
        public string FullName => $"{this.FirstName} {this.LastName}";

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("User Name")]
        public string UserName { get; set; }

        [DisplayName("Mobile Number")]
        public string MobileNumber { get; set; }
        public string Avatar { get; set; }

        [DisplayName("User Type")]
        public string UserTypeId { get; set; }
        [DisplayName("Is Online")]
        public bool IsOnline { get; set; }
        [DisplayName("Last Login Date")]
        public DateTime? LastLoginDate { get; set; }

        [DisplayName("Login Count")]
        public int LoginCount { get; set; }
        public bool IsActive { get; set; }

        public string Role { get; set; }
    }
}
