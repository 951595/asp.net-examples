using Microsoft.AspNetCore.Mvc;
using student.api.Model;

namespace student.api.Repo.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<Student> GetStudentById(int id);
    }
}
