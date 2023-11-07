using DSCC.CW1_API._11193.DAL;
using DSCC.CW1_API._11193.Models;

namespace DSCC.CW1_API._11193.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        // initialize DbContext
        private readonly EmployeeContext _dbContext;

        public DepartmentRepository(EmployeeContext dbContext)
        {
            // assign DbContext
            _dbContext = dbContext;
        }

        public void InsertDepartment(Department department)
        {
            // inserting
            _dbContext.Add(department);
            Save();
        }

        public void UpdateDepartment(Department department)
        {
            // updating entry
            _dbContext.Entry(department).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }

        public void DeleteDepartment(int id)
        {
            // find the department to delete
            var department = _dbContext.Departments.Find(id);
            // deleting
            _dbContext.Departments.Remove(department);
            Save();
        }

        public Department GetDepartmentById(int id)
        {
            // find the department to see details of
            var department = _dbContext.Departments.Find(id);
            // return the found department entry
            return department;
        }

        public IEnumerable<Department> GetDepartments()
        {
            // getting list of all departments
            return _dbContext.Departments.ToList();
        }

        public void Save()
        {
            // saving
            _dbContext.SaveChanges();
        }
    }
}
