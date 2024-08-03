using Microsoft.AspNetCore.Mvc;
using Odev_1.Models;
using System.Diagnostics;

namespace Odev_1.Controllers
{
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
            Product product = new Product()
            {
                ProductName = "Klavye",
                Price = 1000,
                Discount = 10,
            };
            return View(product);
        }

        [HttpPost]
        public IActionResult Create(Product model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Error");
        }

        public IActionResult Error()
        {
            return View();
        }

      
    }
}
