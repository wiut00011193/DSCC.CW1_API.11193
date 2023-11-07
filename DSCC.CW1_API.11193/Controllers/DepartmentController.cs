using DSCC.CW1_API._11193.Models;
using DSCC.CW1_API._11193.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace DSCC.CW1_API._11193.Controllers
{
    // set Route
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : Controller
    {
        // initialize repository
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            // assign repository
            _departmentRepository = departmentRepository;
        }

        // GET: api/Department
        [HttpGet]
        public IActionResult Get()
        {
            // get all entries
            var departments = _departmentRepository.GetDepartments();
            return new OkObjectResult(departments);
        }

        // GET: api/Department/5
        [HttpGet("{id}", Name = "GetD")]
        public IActionResult Get(int id)
        {
            // find and get entry by id
            var department = _departmentRepository.GetDepartmentById(id);
            return new OkObjectResult(department);
        }

        // POST: api/Department
        [HttpPost]
        public IActionResult Post([FromBody] Department department)
        {
            using (var scope = new TransactionScope())
            {
                // insert entry
                _departmentRepository.InsertDepartment(department);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = department.ID }, department);
            }
        }

        // PUT: api/Department/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Department department)
        {
            // check if department is null
            if (department != null)
            {
                using (var scope = new TransactionScope())
                {
                    // update entry
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
            // delete entry
            _departmentRepository.DeleteDepartment(id);
            return new OkResult();
        }
    }
}
