using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateGrades.Models
{
    public class Years
    {
        [Key]
        [DisplayName("מספר שנה")]
        public int YearNum { get; set; }
        [Required]
        [DisplayName("שם השנה")]
        public string Year { get; set; }
    }
}
