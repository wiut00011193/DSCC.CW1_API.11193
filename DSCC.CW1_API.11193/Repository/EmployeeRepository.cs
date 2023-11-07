using Microsoft.EntityFrameworkCore;
using DSCC.CW1_API._11193.DAL;
using DSCC.CW1_API._11193.Models;

namespace DSCC.CW1_API._11193.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        // initialize DbContext
        private readonly EmployeeContext _dbContext;

        public EmployeeRepository(EmployeeContext dbContext)
        {
            // assign DbContext
            _dbContext = dbContext;
        }

        public void InsertEmployee(Employee employee)
        {
            // each employee has department, so find the employee's department and assign it to employeeDepartment field of the Employee entry
            employee.EmployeeDepartment = _dbContext.Departments.Find(employee.EmployeeDepartment.ID);
            // inserting
            _dbContext.Add(employee);
            Save();
        }

        public void UpdateEmployee(Employee employee)
        {
            // updating entry
            _dbContext.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }

        public void DeleteEmployee(int id)
        {
            // find the employee to delete
            var employee = _dbContext.Employees.Find(id);
            // deleting
            _dbContext.Employees.Remove(employee);
            Save();
        }

        public Employee GetEmployeeById(int id)
        {
            // find the employee to see details of
            var employee = _dbContext.Employees.Find(id);
            // return the found employee entry
            return employee;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            // getting list of all employees
            List<Employee> employees = _dbContext.Employees.Include(d => d.EmployeeDepartment).ToList();
            return employees;
        }

        public void Save()
        {
            // saving
            _dbContext.SaveChanges();
        }
    }
}
