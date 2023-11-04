using DSCC.CW1_API._11193.DAL;
using DSCC.CW1_API._11193.Models;

namespace DSCC.CW1_API._11193.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly EmployeeContext _dbContext;

        public DepartmentRepository(EmployeeContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void InsertDepartment(Department department)
        {
            _dbContext.Add(department);
            Save();
        }

        public void UpdateDepartment(Department department)
        {
            _dbContext.Entry(department).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }

        public void DeleteDepartment(int id)
        {
            var department = _dbContext.Departments.Find(id);
            _dbContext.Departments.Remove(department);
            Save();
        }

        public Department GetDepartmentById(int id)
        {
            var department = _dbContext.Departments.Find(id);
            return department;
        }

        public IEnumerable<Department> GetDepartments()
        {
            return _dbContext.Departments.ToList();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
