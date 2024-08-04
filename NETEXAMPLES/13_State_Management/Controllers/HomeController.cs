using _13_State_Management.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _13_State_Management.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            // Session, Cookie
            // Session state, kullan�c�n�n oturum s�resince verilerini saklamam�z� sa�lar. Oturum sona erdi�inde bu veriler silinir.
            // Session state �zellikle kullan�c�ya  bilgilerin saklanmas�  gerekti�inde kullan�l�r. Fakat �ifre,kredi kart� gibi bilgiler saklanmamal�d�r.

            // Session'a veri yazma
            HttpContext.Session.SetString("UserName", "Tahsin Canpolat");

            // Sessiondan veri okuma

            var sessionUserName = HttpContext.Session.GetString("UserName");

            // Cookie state sunucu taraf�nda de�il, kullan�c� (client,taray�c�) taraf�nda saklan�r. Kullan�c� taray�c�s�n� kapay�p
            // a�sa bile cookieler ge�erlilik s�resi boyunca saklan�r. Kesinlikle �zel bilgiler saklanmaz.

            // Cookie olu�turma
            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddMinutes(30),
                HttpOnly = true,
                IsEssential = true
            };

            // Set cookie
            Response.Cookies.Append("UserName", "Tahsin Canpolat", cookieOptions);
            // get cookie
            var cookieUserName = Request.Cookies["UserName"];

            // View e yollayal�m

            ViewBag.SessionUserName = sessionUserName;
            ViewBag.CookieUserName = cookieUserName;
            return View();
        }
    }
}
