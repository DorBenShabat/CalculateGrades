using CalculateGrades.Data;
using CalculateGrades.Models;
using CalculateGrades.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace CalculateGrades.Controllers
{
    
    public class YearsController : Controller
    {
        private readonly ApplicationDB _db;
        private readonly IUnitOfWork unit;

        public YearsController(ApplicationDB db, IUnitOfWork work)
        {
            _db = db;
            unit = work;
        }
        public IActionResult Index()
        {
            IEnumerable<Years> objYearsList = unit.Years.GetAll();
            return View(objYearsList);
        }

        //Get
        public IActionResult Create()
        {
            return View();
        }

        //Post
        [HttpPost]
        public IActionResult Create(Years obj)
        {
            _db.years.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET
        public IActionResult Delete(int? id) 
        {
            var yearsFromDB = unit.Years.GetFirstOrDefault(y => y.YearNum == id);
            return View(yearsFromDB);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? yearNum)
        {
            var obj = unit.Years.GetFirstOrDefault(y => y.YearNum == yearNum);
            unit.Years.Remove(obj);
            unit.Save();
            TempData["Success"] = "נמחקה בהצלחה ! {obj.Year}";
            return RedirectToAction("Index");
        }
        public IActionResult Update(int? id)
        {
            var yearsFromDB = unit.Years.GetFirstOrDefault(y => y.YearNum == id);
            return View(yearsFromDB);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Years obj)
        {
            unit.Years.Update(obj);
            unit.Save();
            return RedirectToAction("Index");
        }
    }
}
