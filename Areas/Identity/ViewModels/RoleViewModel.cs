using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DotNetCoreBoilerplate.Identity.ViewModels
{
    public class RoleViewModel
    {
        [Required]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string Name { get; set; }

        public IList<MvcControllerInfo> SelectedControllers { get; set; }
        public IList<MvcControllerInfo> MvcControllerInfo { get; set; }
        public IList<MvcControllerInfoCont> MvcControllerInfoCont { get; set; }
    }
}
public class RoleClaimsCache
{
    public RoleClaimsCache()
    {
        MvcControllerInfoArea = new List<MvcControllerInfoArea>();
    }
    public string Key { get; set; }
    public IList<MvcControllerInfoArea> MvcControllerInfoArea { get; set; }
}
public class MvcControllerInfoArea
{
    public MvcControllerInfoArea()
    {
        Controller = new List<MvcControllerInfoCont>();
    }
    public string AreaName { get; set; }
    public IList<MvcControllerInfoCont> Controller { get; set; }
}

public class MvcControllerInfoCont
{
    public MvcControllerInfoCont()
    {
        Actions = new List<MvcActionInfo1>();
    }
    public string Id { get; set; }
    public IList<MvcActionInfo1> Actions { get; set; }
}

public class MvcActionInfo1
{
    public string Name { get; set; }
}

public class SecureRoutes
{
    public string Name { get; set; }
}
