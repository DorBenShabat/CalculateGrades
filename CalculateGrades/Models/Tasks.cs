using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CalculateGrades.Models
{
    public class Tasks
    {
        [Key]
        public int TaskId { get; set; }
        [Required]
        [DisplayName("שם מטלה")]
        public string TaskName { get; set; }
        [Required]
        [DisplayName("ציון")]
        public decimal Grade { get; set; }
        [Required]
        [DisplayName("אחוז מציון סופי")]
        public decimal PercentageOfFinalGrade { get; set; }
        [Required]
        public int CourseNum { get; set; }

        [ForeignKey("CourseNum")]
        public Courses Course { get; set; }
    }

}
