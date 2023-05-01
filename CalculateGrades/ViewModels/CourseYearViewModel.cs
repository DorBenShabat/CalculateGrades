using CalculateGrades.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CalculateGrades.ViewModels
{
    public class CourseYearViewModel
    {
       
        [Display(Name = "שם הקורס")]
        public Courses CourseName { get; set; }

       
        [Display(Name = "שנת לימוד")]
        public Years YearNum { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> Years { get; set; }
    }


}
