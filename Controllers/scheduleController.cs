using Microsoft.AspNetCore.Mvc;
using get_fit.Areas.Identity.Data;
using get_fit.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace get_fit.Controllers
{
    public class scheduleController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _db;

        public scheduleController(UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }
        public IActionResult Index()
        {
            try
            {
                ViewBag.userId = _userManager.GetUserId(HttpContext.User);
                string id = ViewBag.userId;
                int wid = 1;
                string workoutGoal = _db.workoutSummary.Where(i => i.id == id).Select(i => i.workoutGoal).AsQueryable().Single();
                string workoutPlace = _db.workoutSummary.Where(i => i.id == id).Select(i => i.place).AsQueryable().Single();
                string workoutTime = _db.workoutSummary.Where(i => i.id == id).Select(i => i.workoutTimeNeed).AsQueryable().Single();
                string workoutDay = _db.workoutSummary.Where(i => i.id == id).Select(i => i.workoutDaysneed).AsQueryable().Single();
                string workoutLevel = _db.workoutSummary.Where(i => i.id == id).Select(i => i.workoutLevel).AsQueryable().Single();
                string exs1 = _db.workoutDeatils.Where(i => i.workoutId == "1").Select(i => i.bodyPart).AsQueryable().Single();
                TempData["workoutGoal"] = workoutGoal;
                TempData["workoutPlace"] = workoutPlace;
                TempData["workoutTime"] = workoutTime;
                TempData["workoutDay"] = workoutDay;
                TempData["workoutLevel"] = workoutLevel;
                TempData["exs1"] = exs1;
                return View(_db.workoutDeatils.ToList());
            }
            catch(Exception ex)
            {
                return Redirect("/Identity/Account/Login");

            }

        }


        public ActionResult getValues()
        {
     

            return View();




        }



    }
}

