using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DotNetCoreBoilerplate.Areas.Identity.Services;

namespace DotNetCoreBoilerplate.Areas.Identity.Filters
{
    public class CustomAuthorizationFilter : IAuthorizationFilter
    {
        private readonly IUserSessionService _userSessionService;
        public CustomAuthorizationFilter(IUserSessionService userSessionService)
        {
            _userSessionService = userSessionService;
        }
        void IAuthorizationFilter.OnAuthorization(AuthorizationFilterContext context)
        {
            if (!IsProtectedAction(context))
                return;

            if (!IsUserAuthenticated(context) || _userSessionService == null)
            {
                context.Result = new RedirectResult("~/Identity/Login");
                return;
            }

            var controllerActionDescriptor = (ControllerActionDescriptor)context.ActionDescriptor;
            //var accessList = JsonConvert.DeserializeObject<IEnumerable<MvcControllerInfoArea>>(userSessionServicestring);

            var accessList = _userSessionService.GetRoleObject();
            var areadetails = accessList?.FirstOrDefault(x => x.AreaName == controllerActionDescriptor.ControllerTypeInfo.GetCustomAttribute<AreaAttribute>()?.RouteValue);
            var controllera = areadetails?.Controller.FirstOrDefault(x => x.Id == controllerActionDescriptor.ControllerName);
            if (controllera != null)
            {
                var Actiontest = controllera.Actions.FirstOrDefault(x => x.Name == controllerActionDescriptor.ActionName);
                if (Actiontest != null)
                {
                    return;
                }
            }
            context.Result = new RedirectResult("~/Identity/Account/AccessDenied");
        }

        private bool IsProtectedAction(AuthorizationFilterContext context)
        {
            if (context.Filters.Any(item => item is IAllowAnonymousFilter))
                return false;

            var controllerActionDescriptor = (ControllerActionDescriptor)context.ActionDescriptor;
            var controllerTypeInfo = controllerActionDescriptor.ControllerTypeInfo;
            var actionMethodInfo = controllerActionDescriptor.MethodInfo;

            var authorizeAttribute = controllerTypeInfo.GetCustomAttribute<AuthorizeAttribute>();
            if (authorizeAttribute != null)
                return true;

            authorizeAttribute = actionMethodInfo.GetCustomAttribute<AuthorizeAttribute>();
            if (authorizeAttribute != null)
                return true;

            return false;
        }

        private bool IsUserAuthenticated(AuthorizationFilterContext context)
        {
            return context.HttpContext.User.Identity.IsAuthenticated;
        }

        //private string GetActionId(AuthorizationFilterContext context)
        //{
        //    var controllerActionDescriptor = (ControllerActionDescriptor)context.ActionDescriptor;
        //    var area = controllerActionDescriptor.ControllerTypeInfo.GetCustomAttribute<AreaAttribute>()?.RouteValue;
        //    var controller = controllerActionDescriptor.ControllerName;
        //    var action = controllerActionDescriptor.ActionName;

        //    return $"{area}:{controller}:{action}";
        //}
    }
}
