using Microsoft.AspNetCore.Mvc;

namespace MichaelSplaver_MidtermProjectCSI350.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("ContactUs")]
        public IActionResult ContactUs()
        {
            return View();
        }

        [Route("UserGuide")]
        public IActionResult UserGuide()
        {
            return View();
        }
    }
}
