using AsyncWebApi.Interfaces;
using AsyncWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AsyncWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        readonly IEmployeeService? _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        // POST api/<EmployeeController>
        [HttpGet("GetEmployees")]
        public List<Employee> GetEmployees()
        {
            try
            {
                return _employeeService.GetEmployees();
            }
           catch(Exception ex)
            {
                return null;
            }
        }
        // POST api/<EmployeeController>
        [HttpGet("GetEmployeesAsync")]
        public async Task<List<Employee>> GetEmployeesAsync()
        {
            try
            {
                return await _employeeService.GetEmployeesAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpPost("AddEmployee")]
        public async Task<EmployeeEntity> AddEmployee([FromBody] EmployeeEntity employee)
        {
            var result = await _employeeService.PostEmployee(employee);

            if (result != null)
            { 
                return result;
            }

            return null;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, EmployeeEntity employee)
        {
            try
            {
                if (id == employee.Id)
                {
                    await _employeeService.UpdateEmployee(employee);
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return Ok("Updated Successfull");
        }

    }
}
