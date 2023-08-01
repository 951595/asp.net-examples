using Microsoft.EntityFrameworkCore;
using student.api.Model;
using student.api.Model.Context;
using student.api.Repo.Interfaces;

namespace student.api.Repo.Implementations
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentContext _context;
        public StudentRepository(StudentContext context)
        {
            _context = context;
        }
        public async Task<Student> GetStudentById(int id)
        {
            return await _context.students.FirstOrDefaultAsync(s => s.id == id);
        }

        public async  Task<IEnumerable<Student>> GetStudents()
        {
            return await _context.students.ToListAsync();
        }
    }
}
