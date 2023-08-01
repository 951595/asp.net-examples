using Microsoft.AspNetCore.Mvc;
using student.api.Model;

namespace student.api.Repo.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<Student> GetStudentById(int id);
        Task<Student> AddStudent(Student student);
        Task<Student> UpdateStudent(int id, Student student);
        Task<Student> DeleteStudent(int id);
    }
}
