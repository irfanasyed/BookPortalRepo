using Boo_Store_Portal_Api.Dto;
using Boo_Store_Portal_Api.IServices;
using Boo_Store_Portal_Api.IServices.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Boo_Store_Portal_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeSevice _employeeService;

        public EmployeeController(IEmployeeSevice employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeDto employeeDto)
        {
            var result = await _employeeService.CreateEmployeeAsync(employeeDto);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            return Ok(employees);
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetAllEmployeeById(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            return Ok(employee);
        }
        [HttpGet("pubid/{id}")]
        public async Task<IActionResult> GetAllEmployeeByPubId(int id)
        {
            var employee = await _employeeService.GetEmployeeByPubIdAsync(id);
            return Ok(employee);
        }
        [HttpGet("fname/{fname}")]
        public async Task<IActionResult> GetAllEmployeeByFname(string fname)
        {
            var employee = await _employeeService.GetEmployeeByFnameAsync(fname);
            return Ok(employee);
        }
        [HttpGet("lname/{lname}")]
        public async Task<IActionResult> GetAllEmployeeByLname(string lname)
        {
            var employee = await _employeeService.GetEmployeeByLnameAsync(lname);
            return Ok(employee);
        }
        [HttpGet("hiredate/{hiredate}")]
        public async Task<IActionResult> GetAllEmployeeByHireDate(DateTime hireDate)
        {
            var employee = await _employeeService.GetEmployeeByHireDateAsync(hireDate);
            return Ok(employee);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] UpdateEmployeeDto updateEmployeeDto)
        {
            var result = await _employeeService.UpdateEmployeeAsync(id, updateEmployeeDto);
            if (result) return NoContent();
            return BadRequest("Failed to update employee.");
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchEmployee(int id, [FromBody] PatchEmployeeDto patchEmployeeDto)
        {
            var result = await _employeeService.PatchEmployeeAsync(id, patchEmployeeDto);
            if (result) return NoContent();
            return BadRequest("Failed to update employee.");
        }
    }
}
