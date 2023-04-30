using CalculateGrades.Data;
using CalculateGrades.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CalculateGrades.Repository.IRepository;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using CalculateGrades.ViewModels;


namespace CalculateGrades.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDB _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDB db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Years> years = _db. years.ToList();
            return View(years);
        }
        
        public IActionResult Details(int YearNum)
        {
           
            Years year = _db.years.FirstOrDefault(y => y.YearNum == YearNum);
            List<Courses> courses = _db.courses.Where(c => c.YearNum == YearNum).ToList();

            YearCoursesViewModel viewModel = new YearCoursesViewModel
            {
                Year = year,
                Courses = courses
            };

            return View(viewModel);
        }



    }
}