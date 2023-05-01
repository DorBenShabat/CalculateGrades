using Microsoft.AspNetCore.Mvc;
using CalculateGrades.Models;
using CalculateGrades.Data;
using CalculateGrades.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using CalculateGrades.Repository.IRepository;

namespace CalculateGrades.Controllers
{
    public class CourseController : Controller
    {
        private readonly IUnitOfWork _db;
        private readonly ApplicationDB _dB;

        public CourseController(IUnitOfWork db, ApplicationDB dB)
        {
            _db = db;
            _dB = dB;
        }
        public IActionResult Index()
        {
            List<Courses> objCoursesToList = _dB.courses.ToList();
            return View(objCoursesToList);
        }

        // GET: Course/Create
        public IActionResult Create()
        {
            CourseYearViewModel viewModel = new CourseYearViewModel
            {
                Years = _dB.years.Select(i => new SelectListItem
                {
                    Text = i.Year,
                    Value = i.YearNum.ToString()
                })
            };
            return View(viewModel);
        }

        // POST: Course/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CourseYearViewModel viewModel)
        {

                    Courses course = new Courses
                    {
                        CourseName = viewModel.CourseName.CourseName,
                        YearNum = viewModel.CourseName.YearNum,
                    };
                    _dB.courses.Add(course);
                    _dB.SaveChanges();
                     return RedirectToAction("Details", "Home", new { yearNum = course.YearNum });

        }



        public IActionResult Details(int? courseNum)
        {
           
            var course = _db.Course.GetFirstOrDefault(c => c.CourseNum == courseNum);

            if (course == null)
            {
                return NotFound();
            }

            var viewModel = new CourseDeatilViewModel
            {
                CourseName = course.CourseName,
                CourseNum = course.CourseNum,
                YearNum = course.YearNum,
                Tasks = _db.Tasks.GetAll(t => t.CourseNum == courseNum)
                    .Select(t => new TasksViewModel
                    {
                        TaskId = t.TaskId,
                        TaskName = t.TaskName,
                        Grade = t.Grade,
                        PercentageOfFinalGrade = t.PercentageOfFinalGrade
                    })
                    .ToList()
            };

            return View(viewModel);
        }

        public IActionResult Upsert(int? courseNum)
        {
            Courses course = _db.Course.GetFirstOrDefault(c => c.CourseNum == courseNum);

            if (course == null)
            {
                return NotFound();
            }

            CourseYearViewModel viewModel = new CourseYearViewModel
            {
                CourseName = course,
                YearNum = course.Year,
                Years = _dB.years.Select(i => new SelectListItem
                {
                    Text = i.Year,
                    Value = i.YearNum.ToString(),
                    Selected = i.YearNum == course.YearNum
                })
            };

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(CourseYearViewModel viewModel)
        {
            Courses course = _dB.courses.Find(viewModel.CourseName.CourseNum);
            if (course == null)
            {
                return NotFound();
            }

            course.CourseName = viewModel.CourseName.CourseName;
            _dB.courses.Update(course);
            _dB.SaveChanges();

            return RedirectToAction("Details", "Home", new { yearNum = course.YearNum });

        }



        #region API Calls
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Courses> objCoursesToList = _dB.courses.ToList();
            return Json(new { data = objCoursesToList });
        }

        
        public IActionResult Delete(int? courseNum)
        {
            var course = _db.Course.GetFirstOrDefault(c => c.CourseNum == courseNum);
            if (course == null)
            {
                return Json(new {
                });
               // return Json(new { success = false, message = "Error while deliting" });
            }

            _db.Course.Remove(course);
            _db.Save();
            return Json(new { success = true, message = "Delete Successful" });

        }

       

        #endregion
    }
}
