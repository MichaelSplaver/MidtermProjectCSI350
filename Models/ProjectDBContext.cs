using Microsoft.EntityFrameworkCore;

namespace MichaelSplaver_MidtermProjectCSI350.Models
{
    public class ProjectDBContext : DbContext
    {
        public ProjectDBContext(DbContextOptions<ProjectDBContext> options) : base(options) { }
        public DbSet<Assignment> Assignments => Set<Assignment>();
        public DbSet<Course> Courses => Set<Course>();
        public DbSet<Teacher> Teachers => Set<Teacher>();
    }
}
