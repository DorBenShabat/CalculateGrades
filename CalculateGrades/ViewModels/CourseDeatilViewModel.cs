using CalculateGrades.Models;

namespace CalculateGrades.ViewModels
{
    public class CourseDeatilViewModel
    {
        public string CourseName { get; set; }
        public int CourseNum { get; set; }
        public int YearNum { get; set; }
        public float Grade { get; set; }
        public List<TasksViewModel> Tasks { get; set; }

        public string FinalGrade
        {
            get
            {
                decimal sum = 0;
                foreach (var task in Tasks)
                {
                    sum += (task.Grade * task.PercentageOfFinalGrade) / 100;
                }
                return sum.ToString("0.00");
            }
        }

    }
}
