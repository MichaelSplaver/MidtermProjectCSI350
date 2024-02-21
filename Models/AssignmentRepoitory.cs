namespace MichaelSplaver_MidtermProjectCSI350.Models
{
    public class AssignmentRepoitory
    {
        private ProjectDBContext context;
        public AssignmentRepoitory(ProjectDBContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Assignment> Assignments => context.Assignments;
        public IQueryable<Course> Courses => context.Courses;
        public IQueryable<Teacher> Teachers => context.Teachers;
    }
}
