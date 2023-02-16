using get_fit.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using get_fit.Areas.Identity.Data;

namespace get_fit.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _db;
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
            _db = db;
        }

        public async Task<IActionResult> IndexAsync()
        {
           var userId = _userManager.GetUserId(HttpContext.User);

            if (String.IsNullOrEmpty(userId))
            {
                return View();
            }

            var goalValue = _db.workoutSummary.Where(i => i.id == userId).Select(i => i.workoutGoal).AsQueryable().SingleOrDefault();
            TempData["goalValue"] = goalValue;
            TempData["user"] = userId;

            return View();
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}