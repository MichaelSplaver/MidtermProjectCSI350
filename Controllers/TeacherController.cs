using Microsoft.AspNetCore.Mvc;
using MichaelSplaver_MidtermProjectCSI350.Models;
using System.Text;
using Microsoft.Net.Http.Headers;
using NuGet.Protocol;

namespace MichaelSplaver_MidtermProjectCSI350.Controllers
{
    public class TeacherController : Controller
    {
        private AssignmentRepoitory repo;

        public TeacherController(AssignmentRepoitory repo)
        {
            this.repo = repo;
        }

        [Route("Teachers")]
        public IActionResult Index()
        {
            return View(repo.Teachers);
        }

        [Route("Json/Teachers/teachers.json")]
        public JsonResult JsonView()
        {
            return Json(repo.Teachers);
        }

        [Route("Teachers/TextFile/teachers.txt")]
        public IActionResult TextView()
        {
            return Content(teachersToString(repo.Teachers));
        }

        [Route("Downloads/Teachers")]
        public IActionResult Downloads()
        {
            return View();
        }


        public IActionResult TextDownload()
        {
            var stream = new MemoryStream(Encoding.ASCII.GetBytes(teachersToString(repo.Teachers)));
            return new FileStreamResult(stream, new MediaTypeHeaderValue("text/plain"))
            {
                FileDownloadName = "teachers.txt"
            };
        }

        public IActionResult JsonDownload()
        {
            var stream = new MemoryStream(Encoding.ASCII.GetBytes(Json(repo.Teachers).ToJson()));
            return new FileStreamResult(stream, new MediaTypeHeaderValue("text/json"))
            {
                FileDownloadName = "teachers.json"
            };
        }


        private string teachersToString(IQueryable<Teacher> teacherList)
        {
            var returnstring = "";
            foreach (var teacher in teacherList)
            { 
                returnstring += "Teacher ID: " + teacher.TeacherID + "\n";
                returnstring += "First Name: " + teacher.FirstName + "\n";
                returnstring += "Teacher ID: " + teacher.LastName + "\n";
                returnstring += "Graduate School: " + teacher.DegreeSchool + "\n\n";
            }
            return returnstring;
        }
    }
}
