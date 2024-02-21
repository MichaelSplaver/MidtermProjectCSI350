using System.ComponentModel.DataAnnotations;

namespace MichaelSplaver_MidtermProjectCSI350.Models
{
    public class Assignment
    {
        [Key]
        public long AssignmentID { get; set; }
        public string AssignmentName { get; set; }
        public int AvailablePoints { get; set; }
        public Course Course { get; set; }
    }
}
