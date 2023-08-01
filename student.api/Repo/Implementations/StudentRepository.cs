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
        public async Task<Student> AddStudent(Student student)
        {
            var st = await _context.students.AddAsync(student);
            await _context.SaveChangesAsync();
            return st.Entity;
        }

        public async Task<Student> UpdateStudent(int id, Student student)
        {

            var stu = await _context.students.FirstOrDefaultAsync(s => s.id == id);
            if(stu != null)
            {
                stu.name = student.name;
                stu.marks = student.marks;
                stu.address = student.address;
                await _context.SaveChangesAsync();
                return stu;
            }
            return null;
        }

        public async Task<Student> DeleteStudent(int id)
        {
            var stu = await _context.students.FirstOrDefaultAsync(s => s.id == id);
            if (stu != null)
            {
                _context.students.Remove(stu);
                await _context.SaveChangesAsync();

            }
            return stu;
        }
    }
}
