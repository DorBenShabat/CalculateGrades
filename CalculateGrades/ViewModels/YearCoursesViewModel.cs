using CalculateGrades.Models;

namespace CalculateGrades.ViewModels
{
    public class YearCoursesViewModel
    {
        public Years Year { get; set; }
        public List<Courses> Courses { get; set; }
    }
}
