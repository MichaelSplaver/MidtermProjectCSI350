using Microsoft.AspNetCore.Mvc;

namespace MichaelSplaver_MidtermProjectCSI350.Controllers
{
    public class DataController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
