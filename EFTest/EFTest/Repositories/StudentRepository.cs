using EFTest.Data;
using EFTest.Interfaces;
using EFTest.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Aula02.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolContext _context;

        public StudentRepository(SchoolContext context)
        {
            _context = context; // Armazeno o contexto para ser utilizado no StudentRepository
        }
        public async Task Create(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Student student)
        {
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Student>> GetAll()
        {
            var data = await _context.Students.Include(sc => sc
                .StudentCourses!)
                .ThenInclude(sc => sc.Course)
                .ToListAsync();
            return data;
        }

        public async Task<Student?> GetById(int id)
        {
            var student = await _context.Students.Where(s => s.Id == id).FirstOrDefaultAsync();

            return student;
        }

        public async Task<List<Student>> GetByName(string name)
        {
            var students = await _context.Students.Where(s => s.FirstMidName!.ToLower().Contains(name.ToLower())).ToListAsync();

            return students;
        }
    }
}