
namespace DotNetCoreBoilerplate.Areas.Identity.Services
{
    using Microsoft.AspNetCore.Http;
    using System.Collections.Generic;
    using DotNetCoreBoilerplate.Areas.Identity.Extensions;
    using DotNetCoreBoilerplate.Common;
    using DotNetCoreBoilerplate.Identity.ViewModels;

    /// <summary>
    /// The user session service.
    /// </summary>
    public class UserSessionService : IUserSessionService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IRolesList _RolesList;

        public string SessionKeyName;
        public UserSessionService(IRolesList irolesList, IHttpContextAccessor httpContextAccessor)
        {
            _RolesList = irolesList;
            _httpContextAccessor = httpContextAccessor;
            SessionKeyName = Startup.UserSessionKey;
        }

        //public  ApplicationUserVM ApUser;
        public AlertNotification AlertNotification =>
                  (SessionMessage.Message != null && SessionMessage.Title != null)
                      ? new AlertNotification
                      {
                          PageAlertType = SessionMessage.PageAlertType,
                          NotificationMessage = SessionMessage.Message,
                          Title = SessionMessage.Title
                      }
                      : null;

        public void ClearAlertNotification()
        {
            SessionMessage.Message = null;
            SessionMessage.Title = null;
        }



        public ApplicationUserVM GetCurrentUser()
        {
            return _httpContextAccessor.HttpContext.Session.GetObject<ApplicationUserVM>(SessionKeyName);
        }

        public string GetCurrentRole()
        {
            var User = _httpContextAccessor.HttpContext.Session.GetObject<ApplicationUserVM>(SessionKeyName);
            if (User != null)
            {
                return _RolesList.GetValue(User.RoleName);
            }
            else
            {
                return null;
            }
        }

        public IList<MvcControllerInfoArea> GetRoleObject()
        {
            var User = _httpContextAccessor.HttpContext.Session.GetObject<ApplicationUserVM>(SessionKeyName);
            if (User != null)
            {
                return _RolesList.GetObject(User.RoleName); 
            }
            else
            {
                return null;
            }
        }

        public void CreateSession(ApplicationUserVM user)
        {
            _httpContextAccessor.HttpContext.Session.SetObject<ApplicationUserVM>(SessionKeyName, user);
        }
    }
}