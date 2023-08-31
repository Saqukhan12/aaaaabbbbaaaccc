using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreBoilerplate.Areas.Identity.Services;
using DotNetCoreBoilerplate.Common;
using DotNetCoreBoilerplate.Common.BaseEntity;
using DotNetCoreBoilerplate.Common.Enum;
using DotNetCoreBoilerplate.Controllers;
using DotNetCoreBoilerplate.Data;
using DotNetCoreBoilerplate.Identity.Models;
using DotNetCoreBoilerplate.Identity.ViewModels;

namespace DotNetCoreBoilerplate.Areas.Identity.Controllers
{
    [Authorize]
    [Area("Identity")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<string> _logger;
        public readonly ApplicationDbContext _context;

        public string SessionKeyName;
        private readonly IWebHostEnvironment _appEnvironment;

        private readonly IUserSessionService _userSessionService;
        private readonly ApplicationUserVM CurrentUser;
        public ApplicationUserVM SessionInfoApUser { get; private set; }

        public AccountController(IUserSessionService userSessionService, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ILogger<string> logger, ApplicationDbContext context, IWebHostEnvironment appEnvironment)
        {
            _userSessionService = userSessionService;
            _userManager = userManager;
            _logger = logger;
            _context = context;
            _appEnvironment = appEnvironment;
            CurrentUser = userSessionService.GetCurrentUser();
            SessionKeyName = Startup.UserSessionKey;
        }
        public async Task<IActionResult> ChangePicture(string id)
        {
            var ant = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            return View(ant);
        }
        public ActionResult Module()
        {
            return View();
        }

        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var DeleteUser = _context.Users.FirstOrDefault(c => c.Id == id);
                DeleteUser.IsActive = false;
                await _context.SaveChangesAsync();
                SessionMessage.InitiateSessionMessage(PageAlertType.Success, "User", "Inactive Successfully");
            }
            catch (Exception ex)
            {
                SessionMessage.InitiateSessionMessage(PageAlertType.Success, "User", ex.InnerException.ToString());
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Activate(string id)
        {
            try
            {
                var DeleteUser = _context.Users.FirstOrDefault(c => c.Id == id);
                DeleteUser.IsActive = true;
                await _context.SaveChangesAsync();
                SessionMessage.InitiateSessionMessage(PageAlertType.Success, "User", "Activated Successfully");
            }
            catch (Exception ex)
            {
                SessionMessage.InitiateSessionMessage(PageAlertType.Success, "User", ex.InnerException.ToString());
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePicture(ApplicationUser registerViewModel)
        {

            var files = HttpContext.Request.Form.Files;

            foreach (var Image in files)
            {
                if (Image != null && Image.Length > 0)
                {
                    var file = Image;
                    //There is an error here
                    var path = Path.Combine(_appEnvironment.WebRootPath, "usersprofileimage");
                    if (file.Name.Length > 0)
                    {
                        var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
                        using var fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create);
                        file.CopyTo(fileStream);
                    }
                }
            }
            _context.Update(User);
            await _context.SaveChangesAsync();
            SessionMessage.InitiateSessionMessage(PageAlertType.Success, "Account", "Profile Picture Successfully Updated");
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [DisplayName("Create User")]
        public async Task<IActionResult> Register()
        {
            RegisterViewModel registerView = new RegisterViewModel
            {
                UserName = "",
                RoleList = await _context.Roles.Select(x => new GUBaseSelectList() { Id = x.Id, Name = x.Name }).ToListAsync(),
            };
            return this.View(registerView);
        }

        [DisplayName("Create User")]
        public IActionResult Register(string id)
        {
            var UserDetails = _context.Users.AsNoTracking().FirstOrDefault(c => c.Id == id);
            RegisterViewModel register = new RegisterViewModel();

            if (UserDetails != null)
            {
                var UpdateRole = _context.UserRoles.AsNoTracking().FirstOrDefault(c => c.UserId == UserDetails.Id)?.RoleId;
                var RoleName = _context.Roles.AsNoTracking().FirstOrDefault(c => c.Id == UpdateRole)?.Name;

                register = new RegisterViewModel
                {
                    RoleList = _context.Roles.Select(x => new GUBaseSelectList() { Id = x.Id, Name = x.Name }).ToList(),
                    ApplicationUserID = id,
                    Email = UserDetails.Email,
                    FirstName = UserDetails.FirstName,
                    LastName = UserDetails.LastName,
                    UserName = UserDetails.UserName,
                    Role = RoleName,
                };
            }

            register.RoleList = _context.Roles.Select(x => new GUBaseSelectList() { Id = x.Id, Name = x.Name }).ToList();
            return View(register);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel Input)
        {
            if (ModelState.IsValid)
            {
                if (Input.UserName != null)
                {
                    var files = HttpContext.Request.Form.Files;
                    var user = new ApplicationUser
                    {
                        UserName = Input.UserName.Trim(),
                        Email = Input.UserName.Trim(),
                        FirstName = Input.FirstName,
                        LastName = Input.LastName,
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                        IsActive = true,
                    };
                    var result = await _userManager.CreateAsync(user, Input.Password);
                    if (result.Succeeded == false)
                    {
                        SessionMessage.InitiateSessionMessage(PageAlertType.Error, "User", "Already Exists");
                        ViewBag.UserName = user.UserName;
                        Input.RoleList = await _context.Roles.Select(x => new GUBaseSelectList() { Id = x.Id, Name = x.Name }).ToListAsync();
                        return View(Input);
                    }
                    else if (result.Succeeded)
                    {
                        SessionMessage.InitiateSessionMessage(PageAlertType.Success, "User", "Successfully Created");
                        _logger.LogInformation("User created a new account with password.");
                        await _userManager.AddToRoleAsync(user, Input.Role);

                        _context.SaveChanges();
                        SessionMessage.InitiateSessionMessage(PageAlertType.Success, "User", "User Created Successfully");
                        return RedirectToAction(nameof(Index));
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
                else
                {
                    SessionMessage.InitiateSessionMessage(PageAlertType.Error, "Accounts", "User Allocation Cannot Be Null");
                }
            }

            Input = new RegisterViewModel
            {
                UserName = "",
                RoleList = await _context.Roles.Select(x => new GUBaseSelectList() { Id = x.Id, Name = x.Name }).ToListAsync(),
            };
            return View(Input);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditRegister(RegisterViewModel registerViewModel, IFormFile ImageFile, string returnUrl = null)
        {
            try
            {
                returnUrl ??= Url.Content("~/");

                var User = await _context.Users.FirstOrDefaultAsync(c => c.Id == registerViewModel.ApplicationUserID);

                //Get Previous Roles
                var roles = await this._userManager.GetRolesAsync(User);
                await this._userManager.RemoveFromRolesAsync(User, roles.ToArray());
                //Assign Role to user here
                await this._userManager.AddToRoleAsync(User, registerViewModel.Role);
                await _context.SaveChangesAsync();

                User.UserName = registerViewModel.UserName;
                User.Email = registerViewModel.UserName;
                User.FirstName = registerViewModel.FirstName;
                User.LastName = registerViewModel.LastName;
                User.CreatedDate = User.CreatedDate;
                User.UpdatedDate = DateTime.Now;
                User.IsActive = true;
                var result = await _userManager.UpdateAsync(User);

                await _context.SaveChangesAsync();
                SessionMessage.InitiateSessionMessage(PageAlertType.Success, "User", "Update Successfully");
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                SessionMessage.InitiateSessionMessage(PageAlertType.Error, "User", "Update Failed");
                throw;
            }
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return this.View();
        }

        [DisplayName("User List")]
        public async Task<IActionResult> Index()
        {
            var Users = await _context.Users.AsNoTracking().ToListAsync();
            return View(Users);
        }

        [DisplayName("Assign only this function to Users, to enable them to reset own password")]
        public IActionResult PasswordReset()
        {
            try
            {
                var UserDetails = _userSessionService.GetCurrentUser();
                PasswordResetViewModel model = new PasswordResetViewModel
                {
                    UserName = UserDetails.UserName,
                    ApplilicationUserId = UserDetails.ApplicationUserId
                };
                return View(model);
            }
            catch (Exception)
            {
                SessionMessage.InitiateSessionMessage(PageAlertType.Error, "Password", "Reset Error Contact Admin");

                return Redirect("/Identity/Login/Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> PasswordReset(PasswordResetViewModel PasswordResetViewModel)
        {
            try
            {
                var UserDetails = _context.Users.FirstOrDefault(c => c.Id == PasswordResetViewModel.ApplilicationUserId);
                string Oldpassword = _userManager.PasswordHasher.VerifyHashedPassword(UserDetails, UserDetails.PasswordHash, PasswordResetViewModel.OldPassword).ToString();
                if (Oldpassword == "Success")
                {
                    // Get the user by email - may need to be careful of casing here
                    ApplicationUser user = _userManager.Users.First(x => x.Id == PasswordResetViewModel.ApplilicationUserId);
                    // Generate the reset token (this would generally be sent out as a query parameter as part of a 'reset' link in an email)
                    string resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                    // Use the reset token to verify the provenance of the reset request and reset the password.
                    IdentityResult updateResult = await _userManager.ResetPasswordAsync(user, resetToken, PasswordResetViewModel.Password);
                    if (updateResult.Errors.Count() != 0)
                    {
                        string ErrorMessage = "";
                        foreach (var item in updateResult.Errors)
                        {
                            ErrorMessage += item.Description;
                        }
                        PasswordResetViewModel model = new PasswordResetViewModel
                        {
                            ApplilicationUserId = user.Id,
                            UserName = user.UserName,
                            ErrorMessage = ErrorMessage,
                            OldPassword = PasswordResetViewModel.OldPassword
                        };
                        return View(model);
                    }
                    SessionMessage.InitiateSessionMessage(PageAlertType.Success, "Password ", "Reset Successfully");
                    return Redirect("/Home/Index");
                }
                else
                {
                    SessionMessage.InitiateSessionMessage(PageAlertType.Error, "Old Password", "Entered is wrong");
                    return Redirect("/Identity/Login/Logout");
                }
            }
            catch (Exception)
            {
                SessionMessage.InitiateSessionMessage(PageAlertType.Error, "Password Reset Error", "Contact to Admin");
            }
            return Redirect("/Identity/Login/Index");
        }

        [HttpGet]
        public IActionResult Lockout()
        {
            return View();
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }
        private async Task<IActionResult> ExistingPasswordCheck(string Password, string PassId)
        {
            if (Password == null && PassId == null)
            {
                return Content("False");
            }

            var UserDetails = await _context.Users.FirstOrDefaultAsync(c => c.Id == PassId);
            string Oldpassword = "";
            if (UserDetails != null)
            {
                Oldpassword = _userManager.PasswordHasher.VerifyHashedPassword(UserDetails, UserDetails.PasswordHash, Password).ToString();
            }

            if (Oldpassword == "Success" && UserDetails != null)
            {
                return Content("True");
            }
            else
            {
                return Content("False");
            }
        }
        private ApplicationUser ReturnPassword(string userName)
        {
            var queryUserDetails = (from user in _context.Users
                                    where user.Email == userName
                                    select user).SingleOrDefault();
            return queryUserDetails;
        }

        [AllowAnonymous]
        public string CheckUser(string id)
        {
            if (id == null || id == "")
            {
                return "false";
            }
            var UserDetails = _context.Users.AsNoTracking().FirstOrDefault(c => c.UserName.ToLower().Trim() == id.ToLower().Trim());

            if (UserDetails != null)
            {
                return UserDetails.Id.ToString();
            }
            return "false";
        }
    }
}