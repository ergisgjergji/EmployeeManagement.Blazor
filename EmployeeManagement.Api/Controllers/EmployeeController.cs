using EmployeeManagement.Api.Models;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeRepository EmployeeRepository { get; set; }
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            EmployeeRepository = employeeRepository;
        }

        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<Employee>>> Search(string name, Gender? gender)
        {
            try
            {
                var employees = await EmployeeRepository.Search(name, gender);
                return Ok(employees);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("all")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok(await EmployeeRepository.GetAllAsync());
            }
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> Get(int id)
        {
            try
            {
                var result = await EmployeeRepository.GetByIdAsync(id);

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> Create(Employee employee)
        {
            try
            {
                if (employee == null)
                    return BadRequest();

                var duplicateEmail = await EmployeeRepository.GetByEmailAsync(employee.Email);
                if(duplicateEmail != null)
                {
                    ModelState.AddModelError("email", "Email " + employee.Email + " is already in use.");
                    return BadRequest(ModelState);
                }


                var createdEmployee = await EmployeeRepository.CreateAsync(employee);

                return CreatedAtAction(nameof(Get), new { id = createdEmployee.Id }, createdEmployee);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Employee>> Update(int id, Employee employee)
        {
            try
            {
                if (id != employee.Id)
                    return BadRequest("Employee.Id mismatch");

                var employeeToUpdate = await EmployeeRepository.GetByIdAsync(id);
                if (employeeToUpdate == null)
                    return NotFound("Employee with Id = " + id.ToString() + " not found");

                if (employee == null)
                    return BadRequest();

                return await EmployeeRepository.UpdateAsync(employee);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Employee>> Delete(int id)
        {
            try
            {
                var employee = await EmployeeRepository.GetByIdAsync(id);
                if (employee == null)
                    return NotFound("Employee with Id = " + id.ToString() + " not found");

                await EmployeeRepository.DeleteAsync(id);
                return employee;
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
