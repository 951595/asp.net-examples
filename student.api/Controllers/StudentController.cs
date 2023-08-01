using Microsoft.AspNetCore.Mvc;
using student.api.Model;
using student.api.Repo.Interfaces;

namespace student.api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class StudentController:ControllerBase
    {
        public readonly IStudentRepository _repository;
        public StudentController(IStudentRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            return Ok(await _repository.GetStudents());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            var stu = await _repository.GetStudentById(id);
            if(stu == null)
            {
                return NotFound();
            }
            return Ok(stu);
        }

    }
}
