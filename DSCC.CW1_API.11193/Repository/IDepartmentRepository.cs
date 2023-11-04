using DSCC.CW1_API._11193.Models;

namespace DSCC.CW1_API._11193.Repository
{
    public interface IDepartmentRepository
    {
        void InsertDepartment(Department department);
        void UpdateDepartment(Department department);
        void DeleteDepartment(int id);
        Department GetDepartmentById(int id);
        IEnumerable<Department> GetDepartments();
    }
}
