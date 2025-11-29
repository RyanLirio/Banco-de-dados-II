using EFTest.Models;

namespace EFTest.Interfaces
{
    public interface IStudentCoursesRepository
    {
        Task Create(StudentCourses studentCourses);
        Task Update(StudentCourses studentCourses);
        Task Delete(StudentCourses studentCourses);
        Task<StudentCourses?> GetById(int id);
        Task<List<StudentCourses>> GetByName(string name);
        Task<List<StudentCourses>> GetAll();
    }
}
