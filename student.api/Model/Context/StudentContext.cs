using Microsoft.EntityFrameworkCore;

namespace student.api.Model.Context
{
    public class StudentContext:DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {

        }
        public DbSet<Student> students { get; set; }
    }
}
