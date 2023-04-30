using CalculateGrades.Data;
using CalculateGrades.Models;
using Microsoft.AspNetCore.Mvc;

namespace CalculateGrades.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDB _db;
        public LoginController(ApplicationDB db)
        {
            _db = db;
        }
       public IActionResult Index() 
        {
            return View();
        }

    }
}
