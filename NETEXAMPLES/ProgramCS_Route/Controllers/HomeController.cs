using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ProgramCS_Route.Controllers
{
    public class HomeController : Controller
    {
       
        // Index methodu geriye IActionResult d�nd�r�r. Yani geriye view d�nd�r�r.
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
