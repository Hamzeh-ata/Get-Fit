using Microsoft.AspNetCore.Mvc;
using get_fit.Areas.Identity.Data;
using get_fit.Models;
using Microsoft.AspNetCore.Identity;

namespace get_fit.Controllers
{
    public class getScheduleController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _db;
        public getScheduleController(UserManager<ApplicationUser> userManager, ApplicationDbContext db)
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
 

    public ActionResult getValues()
    {

            ViewBag.userId = _userManager.GetUserId(HttpContext.User);
            string id = ViewBag.userId;
            var userInfo = _db.Trainee_information.Where(i => i.UserId == id).Single();

            if (userInfo != null)
            {
                workoutSummaryModel workoutSummaryModel = new workoutSummaryModel();
                workoutSummaryModel.id = id;
                workoutSummaryModel.workoutGoal = userInfo.Goal;
                workoutSummaryModel.workoutLevel = "intermediate";
                workoutSummaryModel.workoutTimeNeed = userInfo.WorkoutHours;
                workoutSummaryModel.workoutDaysneed = userInfo.WorkoutDays;
                workoutSummaryModel.place = userInfo.WorkoutPlace;
                workoutSummaryModel.workoutTotalSets = 0;
                _db.Add(workoutSummaryModel);
                _db.SaveChanges();
            }

            return RedirectToAction("Index", "schedule");



        }


    }
}
