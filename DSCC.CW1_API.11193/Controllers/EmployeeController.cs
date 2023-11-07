using DSCC.CW1_API._11193.Models;
using DSCC.CW1_API._11193.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace DSCC.CW1_API._11193.Controllers
{
    // set Route
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        // initialize repository
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            // assign repository
            _employeeRepository = employeeRepository;
        }

        // GET: api/Employee
        [HttpGet]
        public IActionResult Get()
        {
            // get all entries
            var employees = _employeeRepository.GetEmployees();
            return new OkObjectResult(employees);
        }

        // GET api/Employee/5
        [HttpGet, Route("{id}", Name = "GetE")]
        public IActionResult Get(int id)
        {
            // find and get entry by id
            var employee = _employeeRepository.GetEmployeeById(id);
            return new OkObjectResult(employee);
        }

        // POST api/Employee
        [HttpPost]
        public IActionResult Post([FromBody] Employee employee)
        {
            using (var scope = new TransactionScope())
            {
                // insert entry
                _employeeRepository.InsertEmployee(employee);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = employee.ID }, employee);
            }
        }

        // PUT api/Employee/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Employee employee)
        {
            // check if department is null
            if (employee != null)
            {
                using (var scope = new TransactionScope())
                {
                    // update entry
                    _employeeRepository.UpdateEmployee(employee);
                    scope.Complete();
                    return new OkResult();
                }
            }

            return new NoContentResult();
        }

        // DELETE api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // delete entry
            _employeeRepository.DeleteEmployee(id);
            return new OkResult();
        }
    }
}