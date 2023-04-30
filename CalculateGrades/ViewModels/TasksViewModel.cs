using CalculateGrades.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CalculateGrades.ViewModels
{
    public class TasksViewModel
    {
        public int TaskId { get; set; }
        [DisplayName("שם המטלה")]
        public string TaskName { get; set; }
        [DisplayName("ציון")]
        public decimal Grade { get; set; }
        [DisplayName("אחוז מציון סופי")]
        public decimal PercentageOfFinalGrade { get; set; }
        public Courses CourseNum { get; set; }
    }
}
