using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreBoilerplate.Areas.Identity.Services;
using DotNetCoreBoilerplate.Areas.Identity.ViewModels;
using DotNetCoreBoilerplate.Common;
using DotNetCoreBoilerplate.Common.Enum;
using DotNetCoreBoilerplate.Data;
using DotNetCoreBoilerplate.Identity.Models.UserManagment;
using DotNetCoreBoilerplate.Identity.ViewModels;

namespace DotNetCoreBoilerplate.Controllers
{
    [Area("Identity")]
    [Authorize]
    [DisplayName("Role Management: Assign to Super Admin")]
    public class RoleController : Controller
    {
        private readonly IMvcControllerDiscovery _mvcControllerDiscovery;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly ApplicationDbContext _context;

        public RoleController(IMvcControllerDiscovery mvcControllerDiscovery, RoleManager<ApplicationRole> roleManager, ApplicationDbContext context)
        {
            _mvcControllerDiscovery = mvcControllerDiscovery;
            _roleManager = roleManager;
            _context = context;
        }

        public IActionResult Details(string id)
        {
            try
            {
                ViewBag.roleName = _context.Roles.Where(x => x.Id == id).FirstOrDefault().Name;

                List<ApplicationUserRoleVM> applicationUserRoleVMs = new List<ApplicationUserRoleVM>();
                var UserList = (
                                  from usr in _context.Users
                                  join userRole in _context.UserRoles on usr.Id equals userRole.UserId
                                  join role in _context.Roles on userRole.RoleId equals role.Id
                                  where role.Id == id
                                  select usr).ToList();

                //var Users = _context.Users.ToList();
                foreach (var item in UserList)
                {
                    string UserStatus = "Active";

                    if (item.IsActive == false)
                    {
                        UserStatus = "InActive";
                    }
                    ApplicationUserRoleVM applicationUserRoleVM = new ApplicationUserRoleVM()
                    {
                        UserId = item.UserName,
                        FullName = item.FullName,
                        Id = item.Id,
                        LoginCount = item.LoginCount,
                        LastLoginDate = item.LastLoginDate,
                        IsActive = UserStatus
                    };
                    applicationUserRoleVMs.Add(applicationUserRoleVM);
                }
                return View(applicationUserRoleVMs);
            }
            catch (Exception)
            {
                SessionMessage.InitiateSessionMessage(PageAlertType.Error, "No user Exist Against this Role", "");
                return RedirectToAction("Index");

            }
        }
        // GET: Role
        [DisplayName("List")]
        public ActionResult Index()
        {
            List<UserCountViewModel> RolesList = new List<UserCountViewModel>();
            var roles = _roleManager.Roles.ToList();
            var UsersRoles = _context.UserRoles.ToList();
            var users = _context.Users.ToList();
            foreach (var item in roles)
            {
                int UserCount = 0;
                var UserId = UsersRoles.FirstOrDefault(c => c.RoleId == item.Id)?.UserId;
                var useridActive = users.FirstOrDefault(c => c.Id == UserId)?.IsActive;
                if (useridActive == true)
                {
                    UserCount = UsersRoles.Where(c => c.RoleId == item.Id).Count();
                }

                UserCountViewModel VM = new UserCountViewModel
                {
                    RollName = roles.FirstOrDefault(x => x.Id == item.Id)?.Name,
                    Count = UserCount,
                    ApplicationRoleId = item.Id
                };
                RolesList.Add(VM);

            }
            return View(RolesList);
        }

        // GET: Role/Create
        public ActionResult Create()
        {
            ViewData["Controllers"] = _mvcControllerDiscovery.GetControllers().OrderBy(x => x.AreaName).ThenBy(x => x.DisplayName);

            return View();
        }

        // POST: Role/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RoleViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Controllers"] = _mvcControllerDiscovery.GetControllers();
                return View(viewModel);
            }

            List<MvcControllerInfoArea> MvcControllerInfoAreaList = new List<MvcControllerInfoArea>();

            var role = new ApplicationRole { Name = viewModel.Name };
            if (viewModel.SelectedControllers != null && viewModel.SelectedControllers.Any())
            {
                //foreach (var controller in viewModel.SelectedControllers)
                //    foreach (var action in controller.Actions)
                //        action.ControllerId = controller.Id;

                foreach (var area in viewModel.SelectedControllers.GroupBy(x => x.AreaName))
                {
                    var ObjArea = new MvcControllerInfoArea();
                    ObjArea.AreaName = area.FirstOrDefault().AreaName;
                    List<MvcControllerInfoCont> MvcControllerInfoContList = new List<MvcControllerInfoCont>();
                    foreach (var controller1 in area)
                    {
                        var objcontroller = new MvcControllerInfoCont()
                        {
                            Id = controller1.Name,
                        };

                        List<MvcActionInfo1> MvcActionInfo1List = new List<MvcActionInfo1>();
                        foreach (var action in controller1.Actions)
                        {
                            var MvcActionInfo1 = new MvcActionInfo1()
                            {
                                Name = action.Name,
                            };
                            MvcActionInfo1List.Add(MvcActionInfo1);
                        }
                        objcontroller.Actions = MvcActionInfo1List;

                        MvcControllerInfoContList.Add(objcontroller);

                    }
                    ObjArea.Controller = MvcControllerInfoContList;
                    MvcControllerInfoAreaList.Add(ObjArea);
                }
                var accessJson = JsonConvert.SerializeObject(MvcControllerInfoAreaList);
                role.Access = accessJson;
            }

            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
                return RedirectToAction(nameof(Index));

            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);

            ViewData["Controllers"] = _mvcControllerDiscovery.GetControllers();

            return View(viewModel);
        }

        // GET: Role/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            ViewData["Controllers"] = _mvcControllerDiscovery.GetControllers();

            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
                return NotFound();
            var viewModel = new RoleViewModel
            {
                Name = role.Name
            };
            if (role.Access != null)
            {
                var MvcControllerInfoArea = JsonConvert.DeserializeObject<List<MvcControllerInfoArea>>(role.Access);
                viewModel.MvcControllerInfoCont = MvcControllerInfoArea.SelectMany(x => x.Controller).ToList();

                return View(viewModel);
            }
            return View(viewModel);
        }

        // POST: Role/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string id, RoleViewModel viewModel)
        {
            var AllControllers = _mvcControllerDiscovery.GetControllers();

            if (!ModelState.IsValid)
            {
                ViewData["Controllers"] = AllControllers;
                return View(viewModel);
            }

            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                ModelState.AddModelError("", "Role not found");
                ViewData["Controllers"] = AllControllers;
                return View();
            }

            role.Name = viewModel.Name;
            List<MvcControllerInfoArea> MvcControllerInfoAreaList = new List<MvcControllerInfoArea>();
            List<SecureRoutes> SecureRoutesList = new List<SecureRoutes>();

            if (viewModel.SelectedControllers != null && viewModel.SelectedControllers.Any())
            {
                //foreach (var controller in viewModel.SelectedControllers)
                //    foreach (var action in controller.Actions)
                //        action.ControllerId = controller.Id;

                foreach (var area in viewModel.SelectedControllers.GroupBy(x => x.AreaName))
                {
                    var ObjArea = new MvcControllerInfoArea();
                    ObjArea.AreaName = area.FirstOrDefault().AreaName;
                    var CompleteArea = AllControllers.Where(x => x.AreaName == ObjArea.AreaName).ToList();

                    List<MvcControllerInfoCont> MvcControllerInfoContList = new List<MvcControllerInfoCont>();
                    foreach (var controller1 in area)
                    {
                        var objcontroller = new MvcControllerInfoCont()
                        {
                            Id = controller1.Name,
                        };

                        var CompleteController = CompleteArea.Where(x => x.Name == controller1.Name).ToList();
                        List<MvcActionInfo1> MvcActionInfo1List = new List<MvcActionInfo1>();
                        foreach (var action in controller1.Actions)
                        {
                            var MvcActionInfo1 = new MvcActionInfo1()
                            {
                                Name = action.Name,
                            };

                            MvcActionInfo1List.Add(MvcActionInfo1);
                            var CompleteAction = CompleteController[0].Actions.Where(x => x.Name == action.Name && x.RouteAddress != null).FirstOrDefault();
                            if (CompleteAction != null && CompleteAction.RouteAddress != null)
                            {
                                string RouteAddress = null;
                                if (CompleteAction.RouteAddress == "Matching Route")
                                {
                                    RouteAddress = action.ControllerId + ":" + action.Name;
                                }
                                else
                                {
                                    RouteAddress = CompleteAction.RouteAddress;
                                }

                                SecureRoutes secureRoutes = new SecureRoutes()
                                {
                                    Name = RouteAddress
                                };
                                SecureRoutesList.Add(secureRoutes);
                            }
                        }
                        objcontroller.Actions = MvcActionInfo1List;

                        MvcControllerInfoContList.Add(objcontroller);

                    }
                    ObjArea.Controller = MvcControllerInfoContList;
                    MvcControllerInfoAreaList.Add(ObjArea);
                }
                var accessJson = JsonConvert.SerializeObject(MvcControllerInfoAreaList);
                var routeAccess = JsonConvert.SerializeObject(SecureRoutesList);
                role.Access = accessJson;
                role.RouteAccess = routeAccess;
            }

            var result = await _roleManager.UpdateAsync(role);
            if (result.Succeeded)
                return RedirectToAction(nameof(Index));

            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);

            ViewData["Controllers"] = _mvcControllerDiscovery.GetControllers();

            return View(viewModel);
        }

        // Delete: role/5
        [HttpDelete("role/{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                ModelState.AddModelError("Error", "Role not found");
                return BadRequest(ModelState);
            }

            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
                return Ok(new { });

            foreach (var error in result.Errors)
                ModelState.AddModelError("Error", error.Description);

            return BadRequest(ModelState);
        }
    }
}