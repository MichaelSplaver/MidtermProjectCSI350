namespace MichaelSplaver_MidtermProjectCSI350.Models.ViewModels
{
    public class SiteData
    {
        public int CountTeachers { get; set; }
        public int CountAssignments { get; set; }
        public int CountCourses { get; set; }
        public Dictionary<string,int> CoursesPerQuarter { get; set; }
        public Dictionary<string,int> AssignmentsPerCourse { get; set; }
        public Dictionary<string, int> TotalPointsPerCourse { get; set; }
    }
}
