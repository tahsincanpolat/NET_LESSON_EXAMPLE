using _12_DependecyInjection.Models;
using _12_DependecyInjection.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _12_DependecyInjection.Controllers
{
    public class HomeController : Controller
    {

        // IMyService türündeki servisi tutacak bir deðiþken oluþturuyoruz
        private readonly IMyService _myService;

        // Constructorda dependency injection ile servisi dahil ediyoruz.
        public HomeController(IMyService myService)
        {
            _myService = myService;
        }


        public IActionResult Index()
        {
            // Servisten öðrenci listesini alýyoruz.
            List<Student> students = _myService.GetStudents();

            // View e öðrenci listesini yolluyoruz.
            return View(students);
        }

       
    }
}
