using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MichaelSplaver_MidtermProjectCSI350.Models
{
    public class Course
    {
        [Key]
        public long CourseID { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public string Quarter { get; set; }
    }
}
