using System.ComponentModel.DataAnnotations;

namespace MichaelSplaver_MidtermProjectCSI350.Models
{
    public class Teacher
    {
        [Key]
        public long TeacherID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DegreeSchool { get; set; }
    }
}
