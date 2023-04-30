using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateGrades.Models
{
    public class Courses
    {
        [Key]
        [DisplayName("מספר הקורס")]
        public int CourseNum { get; set; }
        [Required]
        [DisplayName("שם הקורס")]
        public string CourseName { get; set; }
        [DisplayName("מספר שנה")]
        public int YearNum { get; set; }

        [ForeignKey("YearNum")]
        public Years Year { get; set; }

    }
}
