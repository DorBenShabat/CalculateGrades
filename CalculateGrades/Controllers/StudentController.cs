using CalculateGrades.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using CalculateGrades.Models;
using System.Data;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace CalculateGrades.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDB _db;

        public StudentController(ApplicationDB db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.TestGrade = "";
            return View(new Marks());
        }
        [HttpPost]
        public IActionResult Index(Models.Marks tg, Marks obj) 
        {
            if (obj.Mark2 == 0)
            {
                ModelState.AddModelError("mark2", "יש להכניס את נתון המשקל המחושב נמצא בעמודה מצד ימין");
            }
            if (obj.Mark3 == 0)
            {
                ModelState.AddModelError("mark3", "יש להכניס את נתון ממוצע הציונים המשוקלל נמצא בסוף העמוד");
            }
            if (ModelState.IsValid) 
            {
                ViewBag.TestGrade = tg.CalculateTest();
            }
            return View();
        }

        
    }
}
