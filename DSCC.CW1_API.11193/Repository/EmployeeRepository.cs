using Microsoft.EntityFrameworkCore;
using DSCC.CW1_API._11193.DAL;
using DSCC.CW1_API._11193.Models;

namespace DSCC.CW1_API._11193.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext _dbContext;

        public EmployeeRepository(EmployeeContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void InsertEmployee(Employee employee)
        {
            employee.EmployeeDepartment = _dbContext.Departments.Find(employee.EmployeeDepartment.ID);
            _dbContext.Add(employee);
            Save();
        }

        public void UpdateEmployee(Employee employee)
        {
            _dbContext.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }

        public void DeleteEmployee(int id)
        {
            var employee = _dbContext.Employees.Find(id);
            _dbContext.Employees.Remove(employee);
            Save();
        }

        public Employee GetEmployeeById(int id)
        {
            var employee = _dbContext.Employees.Find(id);
            return employee;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            List<Employee> employees = _dbContext.Employees.Include(d => d.EmployeeDepartment).ToList();
            return employees;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
