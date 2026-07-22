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

        [HttpPatch("{Id}")]
        public ActionResult<string?> UpdateEmployeeById(int Id, UpdateEmployeeDto updateEmployee)
        {
            return Ok(_employeesService.UpdateEmployeeById(Id, updateEmployee));
        }

        [HttpGet]
        public ActionResult GetAllEmployees()
        {
            return Ok(_employeesService.GetAllEmployees());
        }

        [HttpGet("{Id}")]
        public ActionResult<Employee?> GetEmployeeById(int Id)
        {
            var employee = _employeesService.GetEmployeeById(Id);

            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        [HttpDelete("{Id}")]
        public ActionResult<string?> DeleteEmployeeById(int Id)
        {
            var result = _employeesService.DeleteEmployeeById(Id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
