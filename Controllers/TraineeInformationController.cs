using get_fit.Areas.Identity.Data;
using get_fit.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace get_fit.Controllers
{
    public class TraineeInformationController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _db;
        public TraineeInformationController(UserManager<ApplicationUser> userManager , ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }


        public IActionResult Index()
        {
            
                ViewBag.userId = _userManager.GetUserId(HttpContext.User);
               if(ViewBag.userId == null)
                {
                return Redirect("/Identity/Account/Login");

                }
               else
            {
                return View();

            }
        }
       
        [HttpPost]
        public IActionResult Index(Trainee_information Trainee)
        {
            try
            {
                
                Trainee_information traineeinformation = new Trainee_information();
                ViewBag.userId = _userManager.GetUserId(HttpContext.User);
                Trainee.UserId = ViewBag.userId;
                traineeinformation.Weight = Trainee.Weight;
                traineeinformation.UserId = Trainee.UserId;
                traineeinformation.BirthDay = Trainee.BirthDay;
                traineeinformation.Height = Trainee.Height;
                ViewBag.Goal = TempData["Goal"];

                Trainee.Goal = ViewBag.Goal;

                traineeinformation.Goal = Trainee.Goal;

                TempData["Height"] = Trainee.Height;
                TempData["BirthDay"] = Trainee.BirthDay;
                TempData["Weight"] = Trainee.Weight;
                TempData["Goal"] = Trainee.Goal;

                if (traineeinformation.Goal == null)
                {
                    traineeinformation.Goal = "null";
                }
                Trainee.WorkoutPlace = "none";
                traineeinformation.WorkoutPlace = Trainee.WorkoutPlace;
                Trainee.WorkoutHours = "null";
                Trainee.WorkoutDays = "null";
                traineeinformation.WorkoutHours = Trainee.WorkoutHours;
                traineeinformation.WorkoutDays = Trainee.WorkoutDays;



                _db.Entry(Trainee).State = EntityState.Modified;
                _db.SaveChanges();
              return RedirectToAction("Index", "WorkoutPlace");

            }
            catch (Exception ex)
            {

                throw ex;
            }
            
          
            
            return View();

          
        }


   

    }
  
}
