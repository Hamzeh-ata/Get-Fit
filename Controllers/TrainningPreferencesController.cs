using get_fit.Areas.Identity.Data;
using get_fit.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace get_fit.Controllers
{
    public class TrainningPreferencesController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _db;
        string buttonCheckValue = "None";

        public TrainningPreferencesController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
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
        public IActionResult Index( Trainee_information Trainee , string hoursSelect, string DaysSelect)
        {
            try
            {
                ViewBag.userId = _userManager.GetUserId(HttpContext.User);
                Trainee_information traineeInformation = new Trainee_information();
                Trainee.UserId = ViewBag.userId;
                ViewBag.place = TempData["Place"];
                ViewBag.Weight = TempData["Weight"];
                ViewBag.Height = TempData["Height"];
                ViewBag.BirthDay = TempData["BirthDay"];
                ViewBag.Goal = TempData["Goal"];
                ViewBag.Hours = hoursSelect;
                ViewBag.Days = DaysSelect;
                Trainee.WorkoutPlace = ViewBag.place;
                Trainee.WorkoutHours = ViewBag.Hours;
                Trainee.WorkoutDays = ViewBag.Days;
                Trainee.Height = ViewBag.Height;
                Trainee.BirthDay = ViewBag.BirthDay;
                Trainee.Weight = ViewBag.Weight;
                Trainee.Goal = ViewBag.Goal;
                traineeInformation.Weight = Trainee.Weight;
                traineeInformation.BirthDay = Trainee.BirthDay;
                traineeInformation.Height = Trainee.Height;
                traineeInformation.Goal = Trainee.Goal;
                traineeInformation.WorkoutHours = Trainee.WorkoutHours;
                traineeInformation.WorkoutDays = Trainee.WorkoutDays;
                traineeInformation.WorkoutPlace = Trainee.WorkoutPlace;
                _db.Entry(Trainee).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index", "getSchedule");

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return View();
        }
    }
}
