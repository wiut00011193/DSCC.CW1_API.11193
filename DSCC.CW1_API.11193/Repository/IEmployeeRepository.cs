using DSCC.CW1_API._11193.Models;

namespace DSCC.CW1_API._11193.Repository
{
    public interface IEmployeeRepository
    {
        void InsertEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(int id);
        Employee GetEmployeeById(int id);
        IEnumerable<Employee> GetEmployees();
    }
}
