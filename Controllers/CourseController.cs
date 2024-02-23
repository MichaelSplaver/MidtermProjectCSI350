using Microsoft.AspNetCore.Mvc;
using MichaelSplaver_MidtermProjectCSI350.Models;
using System.Text;
using Microsoft.Net.Http.Headers;
using NuGet.Protocol;

namespace MichaelSplaver_MidtermProjectCSI350.Controllers
{
    public class CourseController : Controller
    {
        private AssignmentRepoitory repo;

        public CourseController(AssignmentRepoitory repo)
        {
            this.repo = repo;
        }

        [Route("Courses/HomePage/Display")]
        public IActionResult Index()
        {
            return View(repo.Courses);
        }

        [Route("Json/Courses/courses.json")]
        public JsonResult JsonView()
        {
            return Json(repo.Courses);
        }

        [Route("Courses/TextFile/courses.txt")]
        public IActionResult TextView()
        {
            return Content(coursesToString(repo.Courses));
        }

        [Route("Downloads/Courses")]
        public IActionResult Downloads()
        {
            return View();
        }

        public IActionResult TextDownload()
        {
            var stream = new MemoryStream(Encoding.ASCII.GetBytes(coursesToString(repo.Courses)));
            return new FileStreamResult(stream, new MediaTypeHeaderValue("text/plain"))
            {
                FileDownloadName = "courses.txt"
            };
        }

        public IActionResult JsonDownload()
        {
            var stream = new MemoryStream(Encoding.ASCII.GetBytes(Json(repo.Courses).ToJson()));
            return new FileStreamResult(stream, new MediaTypeHeaderValue("text/json"))
            {
                FileDownloadName = "courses.json"
            };
        }

        private string coursesToString(IQueryable<Course> courseList)
        {
            var returnstring = "";
            foreach (var course in courseList)
            {
                returnstring += "Course ID: " + course.CourseID + "\n";
                returnstring += "Course Name: " + course.CourseName + "\n";
                returnstring += "Description: " + course.Description + "\n";
                returnstring += "Quarter: " + course.Quarter + "\n\n";
            }
            return returnstring;
        }
    }
}
