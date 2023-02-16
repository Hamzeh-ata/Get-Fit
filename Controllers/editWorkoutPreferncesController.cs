using get_fit.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using get_fit.Models;

namespace get_fit.Controllers
{
    public class editWorkoutPreferncesController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _db;
        public editWorkoutPreferncesController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            try
            {
                ViewBag.userId = _userManager.GetUserId(HttpContext.User);
                string id = ViewBag.userId;
                var goalValue = _db.Trainee_information.Where(i => i.UserId == id).Select(i => i.Goal).AsQueryable().Single();
                TempData["goalValue"] = goalValue;
                var workoutHoursValue = _db.Trainee_information.Where(i => i.UserId == id).Select(i => i.WorkoutHours).AsQueryable().Single();
                TempData["workoutHoursValue"] = workoutHoursValue;
                var workoutDaysValue = _db.Trainee_information.Where(i => i.UserId == id).Select(i => i.WorkoutDays).AsQueryable().Single();
                TempData["workoutDaysValue"] = workoutDaysValue;
                return View();
            }
            catch(Exception ex)
            {
                return Redirect("/Identity/Account/Login");

            }

        }

        [HttpPost]
        public IActionResult changeGoal(string goalSelect)
        {
            try
            {
                if(goalSelect == "Bulking" || goalSelect == "Cutting" || goalSelect == "Lose weight")
                {
                    editWorkoutPreferncesModel editPrefernces = new editWorkoutPreferncesModel();
                    editPrefernces.goal = goalSelect;
                    ViewBag.userId = _userManager.GetUserId(HttpContext.User);
                    string id = ViewBag.userId;
                    var goalValue = _db.Trainee_information.Where(i => i.UserId == id).Single();
                    if(goalValue != null)
                    {
                        goalValue.Goal = editPrefernces.goal;
                        _db.SaveChanges();

                    }
                }
                else
                {
                    return View();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");

        }
   
    [HttpPost]
    public IActionResult changeHours(string workoutHours)
    {
        try
        {
            if (workoutHours == "One hour" || workoutHours == "Two hours" || workoutHours == "More than two hours")
            {
                editWorkoutPreferncesModel editPrefernces = new editWorkoutPreferncesModel();
                editPrefernces.workoutHours = workoutHours;
                ViewBag.userId = _userManager.GetUserId(HttpContext.User);
                string id = ViewBag.userId;
                var hoursValue = _db.Trainee_information.Where(i => i.UserId == id).Single();
                if (hoursValue != null)
                {
                    hoursValue.WorkoutHours = editPrefernces.workoutHours;
                    _db.SaveChanges();
                }
            }
            else
            {
                return View();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return RedirectToAction("Index");
    }
   public IActionResult changeDays(string workoutDays)
        {
            try
            {
                if (workoutDays == "Three days or less per week" || workoutDays == "More than three days per week")
                {
                    editWorkoutPreferncesModel editPrefernces = new editWorkoutPreferncesModel();
                    editPrefernces.workoutDays = workoutDays;
                    ViewBag.userId = _userManager.GetUserId(HttpContext.User);
                    string id = ViewBag.userId;
                    var DaysValue = _db.Trainee_information.Where(i => i.UserId == id).Single();
                    if (DaysValue != null)
                    {
                        DaysValue.WorkoutDays = editPrefernces.workoutDays;
                        _db.SaveChanges();
                    }
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }
    }

}



