using DSCC.CW1_API._11193.Models;
using Microsoft.EntityFrameworkCore;

namespace DSCC.CW1_API._11193.DAL
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> o) : base(o)
        {
            // Ensure database is created
            Database.EnsureCreated();
        }

        // add DbSet below upon new model creation
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
