using CalculateGrades.Data;
using CalculateGrades.Models;
using Microsoft.AspNetCore.Mvc;

namespace CalculateGrades.Controllers
{
    
    public class YearsController : Controller
    {
        private readonly ApplicationDB _db;

        public YearsController(ApplicationDB db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Years> objYearsList = _db.years.ToList();
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
    }
}
