using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeAPI.Data;
using EmployeeAPI.Models;
using EmployeeAPI.Service;

namespace EmployeeAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            return Ok(_employeeRepository.GetAllEmployees());
        }
        [HttpPost]
        public IActionResult CreateEmployee([FromBody] Employee employee)
        {
            if (employee == null) return BadRequest();
            if (employee.FirstName == string.Empty || employee.LastName == string.Empty)
            {
                ModelState.AddModelError("Name/FirstName", "The name or first name shouldn't be empty");
            }
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var createdEmployee = _employeeRepository.AddEmployee(employee);
            return Created("employee", createdEmployee);
        }
        [HttpGet("{employeeId}")]
        public IActionResult GetEmployeeById(int employeeId)
        {
            return Ok(_employeeRepository.GetEmployeeById(employeeId));
        }
        [HttpPut]
        public IActionResult UpdateEmployee([FromBody] Employee employee)
        {
            if (employee == null) return BadRequest();
            if (employee.FirstName == string.Empty || employee.LastName == string.Empty)
            {
                ModelState.AddModelError("Name/FirstName", "The name or first name shouldn't be empty");
            }
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var employeeToUpdate = _employeeRepository.GetEmployeeById(employee.EmployeeId);
            if (employeeToUpdate == null) return NotFound();
            _employeeRepository.UpdateEmployee(employee);
            return NoContent(); //success  
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            if (id == 0) return BadRequest();
            var employeeToDelete = _employeeRepository.GetEmployeeById(id);
            if (employeeToDelete == null) return NotFound();
            _employeeRepository.DeleteEmployee(id);
            return NoContent(); //success  
        }
    }

}
