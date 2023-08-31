using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreBoilerplate.Areas.Identity.Extensions;
using DotNetCoreBoilerplate.Areas.Identity.Models;
using DotNetCoreBoilerplate.Areas.Identity.Services;
using DotNetCoreBoilerplate.Common;
using DotNetCoreBoilerplate.Common.Enum;
using DotNetCoreBoilerplate.Data;
using DotNetCoreBoilerplate.Identity.Models;
using DotNetCoreBoilerplate.Identity.ViewModels;

namespace DotNetCoreBoilerplate.Areas.Identity.Controllers
{
    [Area("Identity")]
    public class LoginController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        public readonly ApplicationDbContext _context;

        public string SessionKeyName;

        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession session => _httpContextAccessor.HttpContext.Session;
        private readonly IUserSessionService _userSessionService;
        private readonly IRolesList _RolesList;

        public LoginController(IRolesList irolesList, IHttpContextAccessor httpContextAccessor, IUserSessionService userSessionService, SignInManager<ApplicationUser> signInManager, ApplicationDbContext context)
        {
            _RolesList = irolesList;
            _httpContextAccessor = httpContextAccessor;
            _userSessionService = userSessionService;
            _signInManager = signInManager;
            _context = context;
            SessionKeyName = Startup.UserSessionKey;
        }


        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            try
            {
                // Removing Session
                HttpContext.Session.Clear();
                // Removing Cookies
                CookieOptions option = new CookieOptions();

                var ant = await _context.Users.FirstOrDefaultAsync(x => x.UserName == this.User.Identity.Name);
                try
                {
                    //ant.IsOnline = false;
                }
                catch (Exception)
                {
                }
                await _context.SaveChangesAsync();
                await _signInManager.SignOutAsync();
                return RedirectToAction("Index", "Login");
            }
            catch (Exception)
            {
                SessionMessage.InitiateSessionMessage(PageAlertType.Error, "Account", "You are already logout");
                return RedirectToAction("Index", "Login");

            }

        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return this.View();
        }

        [DisplayName("Login")]
        public IActionResult Index()
        {
            //if (HttpContext.Session.Keys.Count() < 1)
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            LoginViewModel loginModel = new LoginViewModel();
            return View(loginModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                UserDAL userDAL = new UserDAL(_RolesList, _httpContextAccessor, _userSessionService, _signInManager, _context);
                string URL = await userDAL.LoginPrivate(model);

                if (URL == "Home/index")
                {
                    //SessionMessage.InitiateSessionMessage(PageAlertType.Info, "Welcome back!", $"Asalam.O.Alikum {model.UserName}, You have successfully started your session.");
                    return Redirect("/Home/index");
                }
                else if (URL == "InActive")
                {
                    ViewBag.Error = "Username of Password Failed";
                    SessionMessage.InitiateSessionMessage(PageAlertType.Error, "Accounts", "Something went wrong try again or contect administrator");
                }
                else if (URL == "exception")
                {
                    ViewBag.Error = "Something went wrong try and again or contect admin";
                    SessionMessage.InitiateSessionMessage(PageAlertType.Error, "Accounts", "Something went wrong try again or contect administrator");
                }
            }
            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpGet]
        public IActionResult Lockout()
        {
            return View();
        }
    }
}