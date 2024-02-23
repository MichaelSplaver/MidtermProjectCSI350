using MichaelSplaver_MidtermProjectCSI350.Models;
using MichaelSplaver_MidtermProjectCSI350.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace MichaelSplaver_MidtermProjectCSI350.Controllers
{
    public class DataController : Controller
    {
        private AssignmentRepoitory repo;

        public DataController(AssignmentRepoitory repo)
        {
            this.repo = repo;
        }

        [Route("Site/Data")]
        public IActionResult Index()
        {
            Dictionary<string, int> coursesPerQuarter = new Dictionary<string, int>();
            
            foreach (var quarter in repo.Courses.ToList().GroupBy(course => course.Quarter)) 
            {
                coursesPerQuarter.Add(quarter.Key, quarter.Count());
            }
            
            Dictionary<string, int> assignmentsPerCourse = new Dictionary<string, int>();
            
            foreach (var course in repo.Assignments.Include(assignment => assignment.Course).ToList().GroupBy(assignment => assignment.Course))
            { 
                assignmentsPerCourse.Add(course.Key.CourseName, course.Count()); 
            }
            
            Dictionary<string, int> totalPointsPerCourse = new Dictionary<string, int>();

            foreach (var course in repo.Assignments.Include(assignment => assignment.Course).ToList().GroupBy(assignment => assignment.Course))
            {
                int totalPoints = 0;
                foreach (var item in course)
                {
                    totalPoints += item.AvailablePoints;
                }
                totalPointsPerCourse.Add(course.Key.CourseName, totalPoints); 
            }
            
            var data = new SiteData
            {
                CountAssignments = repo.Assignments.Count(),
                CountCourses = repo.Courses.Count(),
                CountTeachers = repo.Teachers.Count(),
                CoursesPerQuarter = coursesPerQuarter,
                AssignmentsPerCourse = assignmentsPerCourse,
                TotalPointsPerCourse = totalPointsPerCourse
            };

            return View(data);
        }
    }
}
