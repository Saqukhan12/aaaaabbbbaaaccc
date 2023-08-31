using System;

namespace DotNetCoreBoilerplate.Areas.Identity.Extensions
{
    [System.AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]

    public class AuthirizeButtonRoute : Attribute
    {
        readonly string routeAddress;
        public AuthirizeButtonRoute()
        {
            this.routeAddress = "Matching Route";
        }
        public AuthirizeButtonRoute(string routeAddress)
        {
            this.routeAddress = routeAddress;
        }
        public string RouteAddress
        {
            get { return routeAddress; }
        }

    }
}
