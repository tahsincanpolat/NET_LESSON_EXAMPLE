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
            // Session state, kullanýcýnýn oturum süresince verilerini saklamamýzý saðlar. Oturum sona erdiðinde bu veriler silinir.
            // Session state özellikle kullanýcýya  bilgilerin saklanmasý  gerektiðinde kullanýlýr. Fakat þifre,kredi kartý gibi bilgiler saklanmamalýdýr.

            // Session'a veri yazma
            HttpContext.Session.SetString("UserName", "Tahsin Canpolat");

            // Sessiondan veri okuma

            var sessionUserName = HttpContext.Session.GetString("UserName");

            // Cookie state sunucu tarafýnda deðil, kullanýcý (client,tarayýcý) tarafýnda saklanýr. Kullanýcý tarayýcýsýný kapayýp
            // açsa bile cookieler geçerlilik süresi boyunca saklanýr. Kesinlikle özel bilgiler saklanmaz.

            // Cookie oluþturma
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

            // View e yollayalým

            ViewBag.SessionUserName = sessionUserName;
            ViewBag.CookieUserName = cookieUserName;
            return View();
        }
    }
}
