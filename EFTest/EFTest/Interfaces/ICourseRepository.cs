using EFTest.Models;

namespace EFTest.Interfaces
{
    public interface ICourseRepository
    {
        Task Create(Course course);
        Task Update(Course course);
        Task Delete(Course course);
        Task<Course?> GetById(int id);
        Task<List<Course>> GetByName(string name);
        Task<List<Course>> GetAll();
    }
}
