using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ProgramCS_Route.Controllers
{
    public class HomeController : Controller
    {
       
        // Index methodu geriye IActionResult döndürür. Yani geriye view döndürür.
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult AboutDetail()
        {
            return View();
        }

      
    }
}
