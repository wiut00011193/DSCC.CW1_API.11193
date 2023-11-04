using DSCC.CW1_API._11193.Models;
using Microsoft.EntityFrameworkCore;

namespace DSCC.CW1_API._11193.DAL
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> o) : base(o)
        {
            Database.EnsureCreated();
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
