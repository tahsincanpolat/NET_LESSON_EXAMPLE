using _4_ViewBag_ViewData_TempData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace _4_ViewBag_ViewData_TempData.Controllers
{
    public class HomeController : Controller
    {
       
        /*
         Controller'dan view e veri ta��mak i�in kullan�lan y�ntemler
         1. ViewBag: Dinamik bir �zellik olup. Controllerdan view e veri ta��r.
         2. ViewData: S�zl�k (Dictonary) benzeri bir yap�d�r ve controllerdan view e veri ta��r.
         3. TempData: Ge�ici veri ta��mak i�in kullan�l�r ve iki sonu� (action) aras�nda veri ta��r.
         
         
         */
        public IActionResult Index()
        {
            // Viewbag dinamik �zellikler arac�l���yla veri ta��r ve 1 sonu�(action) boyunca ge�erlidir.
            ViewBag.ad = "Tahsin";

            // ViewData, anahtar-de�er ili�kisiyle tutulur. Veri ta��r ve 1 sonu�(action) boyunca ge�erlidir.
            ViewData["soyad"]  = "Canpolat"; //"soyad" de�eri keydir. Ve keye g�re �a��r�m yap�l�r.

            // TempData, ge�ici veriler ta��r ve iki sonu� (action) boyunca ge�erli olabilir.
            TempData["cinsiyet"] = "erkek"; // "cinsiyet" de�eri keydir.Ve keye g�re �a��r�m yap�l�r.

            ViewBag.onay = true;

            return View();
        }

        public IActionResult About()
        {
            ViewData["text"] = ViewData["soyad"]; //  ViewData["soyad"] Index tan�mland��� i�in tek view boyunca ta��n�r.

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
