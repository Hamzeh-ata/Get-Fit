using get_fit.Areas.Identity.Data;
using get_fit.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace get_fit.Controllers
{
    public class TraineeGoalController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _db;
        string buttonCheckValue = "None";


        public TraineeGoalController(UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }

            public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Trainee_information trainee_Information, string button)
        {
            try
            {
                Trainee_information trainee=new Trainee_information();
                ViewBag.userId = _userManager.GetUserId(HttpContext.User);
                trainee.UserId=ViewBag.userId;
                trainee.Weight = 0;
                trainee.Height = 0;
                trainee.BirthDay = "Null";
                trainee.WorkoutPlace = "Null";
                if (button == "bulking")
                {
                    buttonCheckValue = "bulking";
                }
                else if (button == "cutting")
                {
                    buttonCheckValue = "cutting";
                }
                else if(button== "loseWeight")
                {
                    buttonCheckValue = "loseWeight";

                }
                else
                {
                    buttonCheckValue = "none";

                }
                trainee_Information.WorkoutPlace = "none";
                trainee.WorkoutPlace = trainee_Information.WorkoutPlace;
                trainee_Information.WorkoutHours = "null";
                trainee_Information.WorkoutDays = "null";
                trainee.WorkoutHours = trainee_Information.WorkoutHours;
                trainee.WorkoutDays = trainee_Information.WorkoutDays;
                trainee.Goal = buttonCheckValue;
                TempData["Goal"] = trainee.Goal;
                _db.Add(trainee);
                _db.SaveChanges();
                return RedirectToAction("Index", "TraineeInformation");


            }
            catch (Exception ex)
            {
                return Redirect("/Identity/Account/Login");

            }
            return View();
        }

    }
}
