using get_fit.Areas.Identity.Data;
using get_fit.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace get_fit.Controllers
{
    public class WorkoutPlaceController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _db;
        string buttonCheckValue = "None";

        public WorkoutPlaceController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
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
        public ActionResult Index(Trainee_information Trainee, string button)
        {
            try
            {
                if (button == "Gym")
                {
                    buttonCheckValue = "Gym";
                    TempData["ButtonVal"] = buttonCheckValue;

                }
                else
                {
                    buttonCheckValue = "Home";
                    TempData["ButtonVal"] = buttonCheckValue;

                }
                ViewBag.userId = _userManager.GetUserId(HttpContext.User);
                Trainee_information traineeInformation = new Trainee_information();    
                Trainee.UserId = ViewBag.userId;
                Trainee.WorkoutPlace = buttonCheckValue;
                ViewBag.Weight=TempData["Weight"];
                ViewBag.Height = TempData["Height"];
                ViewBag.BirthDay = TempData["BirthDay"];
                ViewBag.Goal = TempData["Goal"];
                TempData["Place"] = Trainee.WorkoutPlace;
                Trainee.Height = ViewBag.Height;
                Trainee.BirthDay = ViewBag.BirthDay;
                Trainee.Weight = ViewBag.Weight;
                Trainee.Goal = ViewBag.Goal;
                Trainee.WorkoutHours = "null";
                Trainee.WorkoutDays = "null";
                traineeInformation.WorkoutHours = Trainee.WorkoutHours;
                traineeInformation.WorkoutDays = Trainee.WorkoutDays;
                traineeInformation.Weight = Trainee.Weight;
                traineeInformation.BirthDay = Trainee.BirthDay;
                traineeInformation.Height = Trainee.Height;
                traineeInformation.Goal = Trainee.Goal;
                traineeInformation.WorkoutPlace = Trainee.WorkoutPlace;
                _db.Entry(Trainee).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index", "TrainningPreferences");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return View();
        }


    }
}
