using get_fit.Areas.Identity.Data;
using get_fit.Areas.Identity.Pages.Account;
using get_fit.Models;
using Microsoft.Owin.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.EntityFrameworkCore;
using static get_fit.Areas.Identity.Pages.Account.RegisterModel;

namespace get_fit.Controllers
{
    public class ManagementController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _db;
        public ManagementController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _db = db;
        }
        public IActionResult Index()
        {

            ViewBag.userId = _userManager.GetUserId(HttpContext.User);
            if (ViewBag.userId == null)
            {
                return Redirect("/Identity/Account/Login");

            }
            else
            {
                return View();

            }
        }
        [HttpPost]
        public async Task<IdentityResult> ChangePassword(mainModel mainModel)
        {
                ViewBag.userId =  _userManager.GetUserId(HttpContext.User);
                var user = await _userManager.FindByIdAsync(ViewBag.userId);
                return await _userManager.ChangePasswordAsync(user, mainModel.changePassword.currentPassword, mainModel.changePassword.newPassword);
        }
        [HttpPost]
        public async Task<IdentityResult> ChangeEmail(mainModel mainModel)
        {
 
            ViewBag.userId = _userManager.GetUserId(HttpContext.User);
            var currentUser = _userManager.FindByIdAsync(ViewBag.userId);
            currentUser.Result.UserName = mainModel.changeEmailModel.newEmail;
            var user = await _userManager.FindByIdAsync(ViewBag.userId);
            await _userManager.SetEmailAsync(user, mainModel.changeEmailModel.newEmail);
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var updateResult = await _userManager.UpdateAsync(user);
            return await _userManager.ChangeEmailAsync(user, mainModel.changeEmailModel.newEmail, token);
           
        }
        [HttpPost]
        public async Task<IdentityResult> ChangeName(mainModel mainModel)
        {
            ViewBag.userId = _userManager.GetUserId(HttpContext.User);
            var currentUser = _userManager.FindByIdAsync(ViewBag.userId);
            currentUser.Result.FirstName = mainModel.userNameChangeModel.firstName;
            currentUser.Result.LastName = mainModel.userNameChangeModel.lastName;
            var user = await _userManager.FindByIdAsync(ViewBag.userId);
            return await _userManager.UpdateAsync(user);

        }
    }
    }
