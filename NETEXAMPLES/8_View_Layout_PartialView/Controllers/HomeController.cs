using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _8_View_Layout_PartialView.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        
    }
}