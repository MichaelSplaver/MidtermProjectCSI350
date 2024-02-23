using Microsoft.AspNetCore.Mvc;
using MichaelSplaver_MidtermProjectCSI350.Models;
using System.Text;
using Microsoft.Net.Http.Headers;
using NuGet.Protocol;
using MichaelSplaver_MidtermProjectCSI350.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace MichaelSplaver_MidtermProjectCSI350.Controllers
{
    public class AssignmentController : Controller
    {
        private AssignmentRepoitory repo;

        public AssignmentController(AssignmentRepoitory repo)
        {
            this.repo = repo;
        }

        [Route("Assignments")]
        public IActionResult Index()
        {
            List<AssignmentWithCourse> assignments = new List<AssignmentWithCourse>();
            foreach (var item in repo.Assignments.Include(assignment => assignment.Course)) 
            {
                assignments.Add(new AssignmentWithCourse
                {
                    AssignmentID = item.AssignmentID,
                    AssignmentName = item.AssignmentName,
                    AvailablePoints = item.AvailablePoints,
                    CourseName = item.Course.Description
                });
            }
            
            return View(assignments);
        }

        [Route("Json/Assignments/assignments.json")]
        public JsonResult JsonView()
        {
            return Json(repo.Assignments);
        }

        [Route("Assignments/TextFile/assignments.txt")]
        public IActionResult TextView()
        {
            return Content(assignmentsToString(repo.Assignments.Include(assignment => assignment.Course)));
        }

        [Route("Downloads/Assignments")]
        public IActionResult Downloads()
        {
            return View();
        }

        public IActionResult TextDownload()
        {
            var stream = new MemoryStream(Encoding.ASCII.GetBytes(assignmentsToString(repo.Assignments.Include(assignment => assignment.Course))));
            return new FileStreamResult(stream, new MediaTypeHeaderValue("text/plain"))
            {
                FileDownloadName = "assignments.txt"
            };
        }

        public IActionResult JsonDownload()
        {
            var stream = new MemoryStream(Encoding.ASCII.GetBytes(Json(repo.Assignments.Include(assignment => assignment.Course)).ToJson()));
            return new FileStreamResult(stream, new MediaTypeHeaderValue("text/json"))
            {
                FileDownloadName = "assignments.json"
            };
        }

        private string assignmentsToString(IQueryable<Assignment> assignments)
        {
            var returnstring = "";
            foreach (var assignment in assignments)
            {
                returnstring += "Assignment ID: " + assignment.AssignmentID + "\n";
                returnstring += "Assignment Name: " + assignment.AssignmentName + "\n";
                returnstring += "Available: " + assignment.AvailablePoints + "\n";
                returnstring += "Course Name: " + assignment.Course.CourseName + "\n\n";
            }
            return returnstring;
        }
    }
}
