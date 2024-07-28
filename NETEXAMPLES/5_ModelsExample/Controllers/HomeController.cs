using _5_ModelsExample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _5_ModelsExample.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            User user = new User()
            {
                Name = "Tahsin",
                Surname = "Canpolat",
                Age = 32
            };


            ViewBag.User = user;
            return View(user);  // model yollayabiliriz.
        }

       
    }
}
