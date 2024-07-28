using _4_ViewBag_ViewData_TempData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace _4_ViewBag_ViewData_TempData.Controllers
{
    public class HomeController : Controller
    {
       
        /*
         Controller'dan view e veri taþýmak için kullanýlan yöntemler
         1. ViewBag: Dinamik bir özellik olup. Controllerdan view e veri taþýr.
         2. ViewData: Sözlük (Dictonary) benzeri bir yapýdýr ve controllerdan view e veri taþýr.
         3. TempData: Geçici veri taþýmak için kullanýlýr ve iki sonuç (action) arasýnda veri taþýr.
         
         
         */
        public IActionResult Index()
        {
            // Viewbag dinamik özellikler aracýlýðýyla veri taþýr ve 1 sonuç(action) boyunca geçerlidir.
            ViewBag.ad = "Tahsin";

            // ViewData, anahtar-deðer iliþkisiyle tutulur. Veri taþýr ve 1 sonuç(action) boyunca geçerlidir.
            ViewData["soyad"]  = "Canpolat"; //"soyad" deðeri keydir. Ve keye göre çaðýrým yapýlýr.

            // TempData, geçici veriler taþýr ve iki sonuç (action) boyunca geçerli olabilir.
            TempData["cinsiyet"] = "erkek"; // "cinsiyet" deðeri keydir.Ve keye göre çaðýrým yapýlýr.

            ViewBag.onay = true;

            return View();
        }

        public IActionResult About()
        {
            ViewData["text"] = ViewData["soyad"]; //  ViewData["soyad"] Index tanýmlandýðý için tek view boyunca taþýnýr.

            TempData["veri"] = TempData["cinsiyet"];

            ViewBag.dersler = new SelectListItem[]
            {
                new SelectListItem { Text = "SQL"},
                new SelectListItem { Text = "C#"},
                new SelectListItem { Text = "JS"}
            };
            return View();
        }

       
    }
}
