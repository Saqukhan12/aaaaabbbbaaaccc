using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using DotNetCoreBoilerplate.Areas.Identity.Extensions;
using DotNetCoreBoilerplate.Areas.Identity.Services;
using DotNetCoreBoilerplate.Identity.ViewModels;
using TechSFrameWork.Models;

namespace DotNetCoreBoilerplate.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationUserVM applicatonUser;
        private readonly IRolesList _RolesList;

        public HomeController(IRolesList irolesList, IUserSessionService IUserSessionService)
        {
            _RolesList = irolesList;
            applicatonUser = IUserSessionService.GetCurrentUser();
        }

        public IActionResult Index()
        {
            var RoleValues = _RolesList.GetObject(applicatonUser.RoleName);
            ViewBag.applicatonUser = JsonConvert.SerializeObject(RoleValues); 
            return View();
        }

        [AuthirizeButtonRoute("Home.About")]
        public IActionResult About()
        {
            return View();
        }

        [AuthirizeButtonRoute]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            return View();
        }

        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }
        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
