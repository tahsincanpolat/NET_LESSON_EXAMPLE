using _11_FluentValidation.Models;
using _11_FluentValidation.ViewModels;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _11_FluentValidation.Controllers
{
    public class HomeController : Controller
    {
        public readonly IValidator<HomePageViewModel> _validator;
        public HomeController(IValidator<HomePageViewModel> validator)
        {
            _validator = validator;
        }
        public IActionResult Index()
        {
           
            return View();
        }

        [HttpPost]
        public IActionResult Submit(HomePageViewModel model)
        {
            // modeli valide et.
            ValidationResult result = _validator.Validate(model);
            // eðer IsValid false ise hatalarý göster
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage); 
                }
                return View("index", model);

            }
            return View("Success",model);
        }

        public IActionResult Success(HomePageViewModel model)
        {
            return View(model);
        }

    }
}
