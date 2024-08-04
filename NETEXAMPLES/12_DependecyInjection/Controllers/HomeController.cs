using _12_DependecyInjection.Models;
using _12_DependecyInjection.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _12_DependecyInjection.Controllers
{
    public class HomeController : Controller
    {

        // IMyService t�r�ndeki servisi tutacak bir de�i�ken olu�turuyoruz
        private readonly IMyService _myService;

        // Constructorda dependency injection ile servisi dahil ediyoruz.
        public HomeController(IMyService myService)
        {
            _myService = myService;
        }


        public IActionResult Index()
        {
            // Servisten ��renci listesini al�yoruz.
            List<Student> students = _myService.GetStudents();

            // View e ��renci listesini yolluyoruz.
            return View(students);
        }

       
    }
}
