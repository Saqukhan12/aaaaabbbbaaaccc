using Microsoft.AspNetCore.Identity;

namespace DotNetCoreBoilerplate.Identity.Models.UserManagment
{
    public class ApplicationRole : IdentityRole
    {
        public string Access { get; set; }
        public string RouteAccess { get; set; }
    }
}