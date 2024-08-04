using _12_DependecyInjection.Models;

namespace _12_DependecyInjection.Services.Abstract
{
    public interface IMyService
    {
        // Öğrenci listesini döndüren gövdesiz bir method
        List<Student> GetStudents();
    }
}
