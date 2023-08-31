namespace DotNetCoreBoilerplate.Areas.Identity.Services
{
    using System.Collections.Generic;
    using DotNetCoreBoilerplate.Common;
    using DotNetCoreBoilerplate.Identity.ViewModels;

    public interface IUserSessionService
    {
        //void CreateSession(ApplicationUserVM user);

        ApplicationUserVM GetCurrentUser();
        string GetCurrentRole();
        IList<MvcControllerInfoArea> GetRoleObject();
        AlertNotification AlertNotification { get; }
        void ClearAlertNotification();
    }
}