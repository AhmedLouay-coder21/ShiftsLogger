using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShiftsLogger.DTO;
using ShiftsLogger.Interfaces;
using ShiftsLogger.Models;

namespace ShiftsLogger.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeesService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeesService = employeeService;
        }

        [HttpPost]
        public ActionResult<string?> AddNewEmployee(Employee employee)
        {
            return Ok(_employeesService.AddNewEmployee(employee));
        }

        [HttpPatch("{id}")]
        public ActionResult<string?> UpdateEmployeeById(int Id, UpdateEmployeeDto updateEmployee)
        {
            return Ok(_employeesService.UpdateEmployeeById(Id, updateEmployee));
        }

        [HttpGet]
        public ActionResult GetAllEmployees()
        {
            return Ok(_employeesService.GetAllEmployees());
        }

        [HttpGet("{id}")]
        public ActionResult<Employee?> GetEmployeeById(int Id)
        {
            return Ok(_employeesService.GetEmployeeById(Id));
        }

        [HttpDelete("{id}")]
        public ActionResult<string?> DeleteEmployeeById(int Id)
        {
            return Ok(_employeesService.DeleteEmployeeById(Id));
        }
    }
}
