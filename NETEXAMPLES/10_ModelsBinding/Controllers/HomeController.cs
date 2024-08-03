using _10_ModelsBinding.Models;
using _10_ModelsBinding.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _10_ModelsBinding.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            Kisi kisi = new Kisi()
            {
                Ad = "Tahsin",
                Soyad = "Canpolat",
                Yas = 32
            };
            return View(kisi);
        }

        [HttpPost]
        public IActionResult Index(Kisi kisi)
        {
           return View(kisi);
        }

        public IActionResult HomePage2()
        {
            Kisi kisi = new Kisi()
            {
                Ad = "Tahsin",
                Soyad = "Canpolat",
                Yas = 32
            };

            Adres adres = new Adres()
            {
                AdresTanim = "Ev Adresi",
                Sehir = "Ýstanbul"
            };
            // Sorun þu => ben homepage2 view ine 2 model yollamak istiyorum.
            HomePageViewModel homePageViewModel = new HomePageViewModel(); // modelleri bind ettim.
            homePageViewModel.AdresNesnesi = adres;
            homePageViewModel.KisiNesnesi = kisi;
            return View(homePageViewModel);
        }


    }
}
