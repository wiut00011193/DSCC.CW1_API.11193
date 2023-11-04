using DSCC.CW1_API._11193.Models;
using DSCC.CW1_API._11193.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace DSCC.CW1_API._11193.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        // GET: api/Department
        [HttpGet]
        public IActionResult Get()
        {
            var departments = _departmentRepository.GetDepartments();
            return new OkObjectResult(departments);
        }

        // GET: api/Department/5
        [HttpGet("{id}", Name = "GetD")]
        public IActionResult Get(int id)
        {
            var department = _departmentRepository.GetDepartmentById(id);
            return new OkObjectResult(department);
        }

        // POST: api/Department
        [HttpPost]
        public IActionResult Post([FromBody] Department department)
        {
            using (var scope = new TransactionScope())
            {
                _departmentRepository.InsertDepartment(department);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = department.ID }, department);
            }
        }

        // PUT: api/Department/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Department department)
        {
            if (department != null)
            {
                using (var scope = new TransactionScope())
                {
                    _departmentRepository.UpdateDepartment(department);
                    scope.Complete();
                    return new OkResult();
                }
            }

            return new NoContentResult();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _departmentRepository.DeleteDepartment(id);
            return new OkResult();
        }
    }
}
