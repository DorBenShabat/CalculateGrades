using CalculateGrades.Data;
using CalculateGrades.Models;
using CalculateGrades.Repository.IRepository;
using CalculateGrades.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CalculateGrades.Controllers
{
    public class TasksController : Controller
    {
        private readonly ApplicationDB _db;
        private readonly IUnitOfWork unit;
        public TasksController(ApplicationDB db, IUnitOfWork work)
        {
            _db= db;
            unit=work;
        }
        public IActionResult Index()
        {
            List<Tasks> tasksToList = _db.Tasks.ToList();
            return View(tasksToList);
        }

        // GET: Task/Create
        public IActionResult Create(int courseNum)
        {
            TasksViewModel viewModel = new TasksViewModel
            {
                CourseNum = _db.courses.FirstOrDefault(c => c.CourseNum == courseNum)
            };
            return View(viewModel);
        }

        // POST: Task/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TasksViewModel viewModel)
        {
            // get the course associated with the assignment
            int courseNum = viewModel.CourseNum.CourseNum;
            Courses course = unit.Course.GetFirstOrDefault(c => c.CourseNum == courseNum);

            // create a new assignment and set its course association
            Tasks task = new Tasks
            {
                TaskName = viewModel.TaskName,
                Grade = viewModel.Grade,
                PercentageOfFinalGrade = viewModel.PercentageOfFinalGrade,
                CourseNum = course.CourseNum
            };

            // save the assignment to the database
            _db.Tasks.Add(task);
            _db.SaveChanges();

            return RedirectToAction("Details", "Course", new { coursenum = course.CourseNum });
        }
        //GET
        public IActionResult Delete(int? taskId)
        {
            var taskFromDB = _db.Tasks.FirstOrDefault(t => t.TaskId == taskId);
            return View(taskFromDB);
        }
        //POST
        [HttpPost]
        public IActionResult DeletePost(int? taskId)
        {
            var obj = _db.Tasks.FirstOrDefault(t => t.TaskId == taskId);
            _db.Tasks.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Details", "Course",new {courseNum = obj.CourseNum} );
        }

        public IActionResult Update(int? taskId)
        {
            var taskFromDB = unit.Tasks.GetFirstOrDefault(t => t.TaskId == taskId);
            return View(taskFromDB);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Tasks obj)
        {
            unit.Tasks.Update(obj);
            unit.Save();
            return RedirectToAction("Details", "Course", new { courseNum = obj.CourseNum });
        }

    }
}
