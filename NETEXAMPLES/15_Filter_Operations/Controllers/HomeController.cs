using _15_Filter_Operations.Filters;
using _15_Filter_Operations.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace _15_Filter_Operations.Controllers
{
    //[ServiceFilter(typeof(AuthorizationFilter))]
    public class HomeController : Controller
    {

        [ServiceFilter(typeof(ActionFilter))]
        public IActionResult Index()
        {
            return View();
        }

        //[ServiceFilter(typeof(AuthorizationFilter))]
        [ServiceFilter(typeof(ExceptionFilter))]
        public IActionResult SpeacialAction()
        {
           throw new Exception("Bu bir test hatasýdýr!");
        }

      
    }
}
