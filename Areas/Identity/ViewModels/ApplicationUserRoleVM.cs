using System;

namespace DotNetCoreBoilerplate.Areas.Identity.ViewModels
{
    public class ApplicationUserRoleVM
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string UserId { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public string IsActive { get; set; }
        public int? LoginCount { get; set; }
    }
}
