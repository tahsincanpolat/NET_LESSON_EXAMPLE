using _7_CustomHelpers.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _7_CustomHelpers.Controllers
{
    public class HomeController : Controller
    {
       

        public IActionResult Index()
        {
            return View();
        }

       
    }
}
