using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace MichaelSplaver_MidtermProjectCSI350.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ProjectDBContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<ProjectDBContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.Courses.Any())
            {
                context.Courses.AddRange(
                    new Course
                    {
                        CourseName = "CSI350",
                        Description = "Software App Development",
                        Quarter = "Winter"
                    },
                    new Course
                    {
                        CourseName = "CSI360",
                        Description = "Mobile App Develop I",
                        Quarter = "Winter"
                    },
                    new Course
                    {
                        CourseName = "CSI410",
                        Description = "IOS Development",
                        Quarter = "Spring"
                    },
                    new Course
                    {
                        CourseName = "CSI420",
                        Description = "React Development",
                        Quarter = "Spring"
                    },
                    new Course
                    {
                        CourseName = "CSI400",
                        Description = "Summer Internship",
                        Quarter = "Summer"
                    }
                );
            }
            if (!context.Assignments.Any()) {
                Dictionary<string,Course> courses = context.Courses.ToDictionary(values => values.CourseName);
                context.Assignments.AddRange(
                    new Assignment { 
                        AssignmentName = "Week 1 Discussion",
                        AvailablePoints = 25,
                        Course = courses["CSI350"]
                    },
                    new Assignment
                    {
                        AssignmentName = "Week 2 Discussion",
                        AvailablePoints = 25,
                        Course = courses["CSI350"]
                    },
                    new Assignment
                    {
                        AssignmentName = "Week 3 Assignment",
                        AvailablePoints = 50,
                        Course = courses["CSI350"]
                    },
                    new Assignment
                    {
                        AssignmentName = "MidTerm Project",
                        AvailablePoints = 100,
                        Course = courses["CSI350"]
                    },
                    new Assignment
                    {
                        AssignmentName = "Week 1 Discussion",
                        AvailablePoints = 25,
                        Course = courses["CSI360"]
                    },
                    new Assignment
                    {
                        AssignmentName = "Week 5 Assignment",
                        AvailablePoints = 75,
                        Course = courses["CSI360"]
                    },
                    new Assignment
                    {
                        AssignmentName = "Week 6 Discussion",
                        AvailablePoints = 25,
                        Course = courses["CSI360"]
                    },
                    new Assignment
                    {
                        AssignmentName = "Week 2 Discussion",
                        AvailablePoints = 25,
                        Course = courses["CSI410"]
                    },
                    new Assignment
                    {
                        AssignmentName = "MidTerm Project",
                        AvailablePoints = 100,
                        Course = courses["CSI410"]
                    },
                    new Assignment
                    {
                        AssignmentName = "Final Project",
                        AvailablePoints = 100,
                        Course = courses["CSI410"]
                    },
                    new Assignment
                    {
                        AssignmentName = "Week 4 Discussion",
                        AvailablePoints = 25,
                        Course = courses["CSI420"]
                    },
                    new Assignment
                    {
                        AssignmentName = "MidTerm Project",
                        AvailablePoints = 100,
                        Course = courses["CSI420"]
                    }
                );
            }
            if (!context.Teachers.Any())
            {
                context.Teachers.AddRange(
                new Teacher
                {
                    FirstName = "Shane",
                    LastName = "Frigon",
                    DegreeSchool = "Washington State University"
                },
                new Teacher
                {
                    FirstName = "Naser",
                    LastName = "Chowdhury",
                    DegreeSchool = "Stanford University"
                },
                new Teacher
                {
                    FirstName = "Carol",
                    LastName = "Higgens",
                    DegreeSchool = "Perdue University"
                }
                );
            }
            context.SaveChanges();
        }
    }
}
