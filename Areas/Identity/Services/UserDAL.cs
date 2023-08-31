using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using DotNetCoreBoilerplate.Data;
using DotNetCoreBoilerplate.Identity.Models;
using DotNetCoreBoilerplate.Identity.ViewModels;
using System.Linq;
using DotNetCoreBoilerplate.Areas.Identity.Extensions;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DotNetCoreBoilerplate.Areas.Identity.Services
{
    public class UserDAL
    {
        //Start Service used for successful login into the application
        private readonly SignInManager<ApplicationUser> _signInManager;
        public readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IRolesList _RolesList;
        public string SessionKeyName;
        //End Service used for successful login into the application
        
        private readonly IUserSessionService _userSessionService;
        private readonly ApplicationUserVM CurrentUser;

        public UserDAL(IRolesList irolesList, IHttpContextAccessor httpContextAccessor, IUserSessionService userSessionService, SignInManager<ApplicationUser> signInManager, ApplicationDbContext context)
        {
            _RolesList = irolesList;
            _httpContextAccessor = httpContextAccessor;
            _userSessionService = userSessionService;
            _signInManager = signInManager;
            _context = context;
            CurrentUser = userSessionService.GetCurrentUser();
            SessionKeyName = Startup.UserSessionKey;
        }

        internal async Task<string> LoginPrivate(LoginViewModel model)
        {
                try
                {
                    var result = await _signInManager.PasswordSignInAsync(model.UserName.Trim(), model.Password, false, lockoutOnFailure: true);
                    if (result.Succeeded)
                    {
                        var user = _context.Users.AsNoTracking().FirstOrDefault(x => x.UserName == model.UserName.Trim());
                        if (user != null)
                        {
                            //_logger.LogInformation("User logged in.");
                            var roles = (
                                from usr in _context.Users
                                join userRole in _context.UserRoles on usr.Id equals userRole.UserId
                                join role in _context.Roles on userRole.RoleId equals role.Id
                                where usr.UserName == user.UserName
                                select role
                            ).AsNoTracking().FirstOrDefault();

                            ApplicationUserVM applicaitonUserVM;
                            applicaitonUserVM = new ApplicationUserVM
                            {
                                ApplicationUserId = user.Id,
                                UserName = user.UserName,
                                FullName = user.FullName,
                                RoleName = roles.Name,
                            };

                            _httpContextAccessor.HttpContext.Session.SetObject<ApplicationUserVM>(SessionKeyName, applicaitonUserVM);
                        //HttpContext.Session.SetObject<string>(applicaitonUserVM.RoleName, roles.Access);

                            var MvcControllerInfoArea = JsonConvert.DeserializeObject<List<MvcControllerInfoArea>>(roles.Access);
                            _RolesList.AddObject(roles.Name, MvcControllerInfoArea);

                            var ant = await _context.Users.FirstOrDefaultAsync(x => x.Id == user.Id);
                            ant.LoginCount += 1;
                            ant.LastLoginDate = DateTime.Now;
                            ant.IsOnline = true;
                            _context.SaveChanges();
                            return "Home/index";
                        }
                        else
                        {
                            await _signInManager.SignOutAsync();
                            return "InActive";
                        }
                    }
                    await _signInManager.SignOutAsync();
                    return "InActive";
                }
                catch (Exception e)
                {
                    return "exception" + e.Message;
                }
        }

    }
}
