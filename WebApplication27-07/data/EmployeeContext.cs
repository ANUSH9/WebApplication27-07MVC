using Microsoft.EntityFrameworkCore;
using WebApplication27_07.Models;

namespace WebApplication27_07.data
{
    public class EmployeeContext:DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
    }
}
