using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _9_Render_Nested_Section.Controllers
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

    }
}
