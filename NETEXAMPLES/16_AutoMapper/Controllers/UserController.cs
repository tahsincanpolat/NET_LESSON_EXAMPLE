using _16_AutoMapper.Dto;
using _16_AutoMapper.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace _16_AutoMapper.Controllers
{
    public class UserController : Controller
    {
        private readonly IMapper _mapper;
        // Dependency injection ile mapper ı dahil edicez.
        public UserController(IMapper mapper)
        {
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var user = new User
            {
                Id = 1,
                FirstName = "Tahsin",
                LastName = "Canpolat",
                Email = "tahsincanpolat@gmail.com"
            };
            // UserDto userDto = user; Hata alırız çünkü birbine eşit sınıflar değiller ve maplenmemiş durumdalar.
            var userDto = _mapper.Map<UserDto>(user);
            return View(userDto);
        }


        public IActionResult MappingTest()
        {
            var userDto = new UserDto
            {
                Id = 1,
                FullName = "Erkan Türk",
                Email = "erkan@gmail.com"
            };

            var user = _mapper.Map<User>(userDto);
          
            return View(user);
        }
    }
}
