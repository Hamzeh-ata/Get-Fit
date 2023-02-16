using Microsoft.AspNetCore.Mvc;

namespace get_fit.Controllers
{
    public class getStartedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
