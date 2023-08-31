namespace DotNetCoreBoilerplate.Identity.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ApplicationUser : IdentityUser
    {
        [StringLength(255)]
        public string FirstName { get; set; }

        [StringLength(255)]
        public string LastName { get; set; }

        [StringLength(255)]
        public string FullName => $"{this.FirstName} {this.LastName}";
        public bool IsOnline { get; set; }
        public bool IsActive { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public int LoginCount { get; set; }
        [MaxLength(128)]

        [NotMapped]
        public string RoleName { get; set; }

        [ScaffoldColumn(false)]
        [StringLength(255)]
        public string CreatedBy { get; set; }

        [ScaffoldColumn(false)]
        public DateTime CreatedDate { get; set; }

        [ScaffoldColumn(false)]
        [StringLength(255)]
        public string UpdatedBy { get; set; }

        [ScaffoldColumn(false)]
        public DateTime UpdatedDate { get; set; }


    }
}