using Microsoft.EntityFrameworkCore;

namespace Employee.Api.Model.Context
{
    public class EmployeeContext:DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {

        }
        public  DbSet<EmployeeData> Employees { get; set;  }
    }
}
