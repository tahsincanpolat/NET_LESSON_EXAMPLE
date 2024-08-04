using _12_DependecyInjection.Models;
using _12_DependecyInjection.Services.Abstract;

namespace _12_DependecyInjection.Services.Concrete
{
    public class MyService : IMyService
    {
        public List<Student> GetStudents()
        {
            return new List<Student>
            {
                new Student {Id = 1, Name = "Ali",Age = 30},
                new Student {Id = 2, Name = "Ayşe" ,Age = 24},
                new Student {Id = 3, Name = "Mehmet",Age = 22},
            };
        }
    }
}
