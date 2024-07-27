using Microsoft.AspNetCore.Mvc;

namespace _2_ControllerToView.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            var products = new List<string> { "Ürün 1", "Ürün 2", "Ürün 3" };
            // Veriyi view data ile yollama
            ViewData["products"] = products;
            return View();
        }
    }
}
