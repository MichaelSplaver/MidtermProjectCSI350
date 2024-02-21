using Microsoft.AspNetCore.Mvc;

namespace MichaelSplaver_MidtermProjectCSI350.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult ContactUs()
        {
            return View();
        }
    }
}
