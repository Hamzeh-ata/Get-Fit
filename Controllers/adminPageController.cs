using get_fit.Areas.Identity.Data;
using get_fit.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace get_fit.Controllers
{
    public class adminPageController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _db;

        public adminPageController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
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
        public ActionResult submit(workoutDeatils workoutDeatils)
        {
            
                workoutDeatils workout_Deatils = new workoutDeatils();
                    workout_Deatils.workoutId = workoutDeatils.workoutId;
                workout_Deatils.bodyPart = workoutDeatils.bodyPart;
                workout_Deatils.exerciseName = workoutDeatils.exerciseName;
                workout_Deatils.reps = workoutDeatils.reps;
                workout_Deatils.sets = workoutDeatils.sets;
                workout_Deatils.videoLink = workoutDeatils.videoLink;
                    _db.Add(workout_Deatils);
                    _db.SaveChanges();

            return View("Index");

        }


    }
}
