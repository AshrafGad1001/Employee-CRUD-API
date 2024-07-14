using Employee_CRUD_API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_CRUD_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeRepository _employeeRepository;
        public EmployeeController(EmployeeRepository employeeRepository)
        {
            this._employeeRepository = employeeRepository;

        }
        [HttpPost]
        public async Task<ActionResult> AddEmployee([FromBody] Employee model)
        {
            await _employeeRepository.AddEmployee(model);
            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult> GetEmployeeList()
        {
            var AllEmployees = await _employeeRepository.GetAllEmployeesAsync();
            return Ok(AllEmployees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetEmployeeById([FromRoute] int id)
        {
            var Employee = await _employeeRepository.GetEmployeeById(id);
            return Ok(Employee);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEmployee([FromRoute] int id, [FromBody] Employee model)
        {
            await _employeeRepository.UpdateEmployee(id, model);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee([FromRoute] int id)
        {
            await _employeeRepository.DeleteEmployeeAsync(id);
            return Ok();
        }

    }
}
