using Microsoft.AspNetCore.Mvc;
using get_fit.Areas.Identity.Data;
using get_fit.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace get_fit.Controllers
{
    public class EditTraineeInformationController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _db;

        public EditTraineeInformationController(UserManager<ApplicationUser> userManager, ApplicationDbContext db)
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
                var birthDayValue = _db.Trainee_information.Where(i => i.UserId == id).Select(i => i.BirthDay).AsQueryable().Single();
                string birthDayValuetoString = Convert.ToString(birthDayValue);
                TempData["birthDayValue"] = birthDayValuetoString;
                var heightValue = _db.Trainee_information.Where(i => i.UserId == id).Select(i => i.Height).AsQueryable().Single();
                string heightValuetoString = Convert.ToString(heightValue);
                TempData["heightValue"] = heightValuetoString;
                var weightValue = _db.Trainee_information.Where(i => i.UserId == id).Select(i => i.Weight).AsQueryable().Single();
                string weightValuetoString = Convert.ToString(weightValue);
                TempData["weightValue"] = weightValuetoString;
                return View();
            }
            catch (Exception ex)
            {
                return Redirect("/Identity/Account/Login");

            }
        }

        [HttpPost]
        public IActionResult ChangeBirthday(changeBirthday changebirthday)
        {
            ViewBag.userId = _userManager.GetUserId(HttpContext.User);
            string id = ViewBag.userId;
            var birthDayValue = _db.Trainee_information.Where(i => i.UserId == id).Single();
            if(birthDayValue != null)
            {
                changeBirthday changeBirthday = new changeBirthday();
                changeBirthday.newBirthDay = changebirthday.newBirthDay;
                birthDayValue.BirthDay = changeBirthday.newBirthDay;
                _db.SaveChanges();

            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ChangeHeight(changeHeight changeheight)
        {
            ViewBag.userId = _userManager.GetUserId(HttpContext.User);
            string id = ViewBag.userId;
            var heightValue = _db.Trainee_information.Where(i => i.UserId == id).Single();
            if (heightValue != null)
            {

                changeHeight changeHeight = new changeHeight();
                changeHeight.Height = changeheight.Height;
                heightValue.Height = changeHeight.Height;
                _db.SaveChanges();

            }
            return RedirectToAction("Index");
        }

       [HttpPost]
        public IActionResult ChangeWeight(changeWeight changeweight)
        {
            ViewBag.userId = _userManager.GetUserId(HttpContext.User);
            string id = ViewBag.userId;
            var weightValue = _db.Trainee_information.Where(i => i.UserId == id).Single();
            if (weightValue != null)
            {
                changeWeight changeWeight = new changeWeight();
                changeWeight.weight = changeweight.weight;
                weightValue.Weight = changeWeight.weight;
                _db.SaveChanges();

            }
            return RedirectToAction("Index");
        }


    }
}
