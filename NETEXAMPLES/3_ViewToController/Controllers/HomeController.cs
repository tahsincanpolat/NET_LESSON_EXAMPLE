using _3_ViewToController.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _3_ViewToController.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet] // Attribute
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string kisiler, string ad, bool onay = true)
        {
            //var k1 = Request.Form["kisiler"];
            //var a1 = Request.Form["ad"];
            //var c1 = Request.Form["onay"].FirstOrDefault();

            var k1 = kisiler;
            var a1 = ad;
            var c1 = onay;
            return View();
        }


    }
}
