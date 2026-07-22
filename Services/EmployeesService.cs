using ShiftsLogger.Data;
using ShiftsLogger.DTO;
using ShiftsLogger.Interfaces;
using ShiftsLogger.Models;

namespace ShiftsLogger.Services
{
    public class EmployeesService : IEmployeeService
    {
        private readonly ShiftsLoggerDbContext _context;
        public EmployeesService(ShiftsLoggerDbContext context)
        {
            _context = context;
        }
        public string? AddNewEmployee(Employee employee)
        {
            if(employee == null)
            {
                return "An error has occurred, The employee was not created!";
            }
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return "A new employee was added successfully";
        }
        public string? UpdateEmployeeById(int Id, UpdateEmployeeDto updatedEmployeeDto)
        {
            var employee = _context.Employees.FirstOrDefault(s => s.Id == Id);

            if (employee == null)
            {
                return "An error has occurred. The employee was not found!";
            }
            if (updatedEmployeeDto.FirstName != null)
                employee.FirstName = updatedEmployeeDto.FirstName;

            if (updatedEmployeeDto.LastName != null)
                employee.LastName = updatedEmployeeDto.LastName;

            if (updatedEmployeeDto.Role != null)
                employee.Role = updatedEmployeeDto.Role;

            if (updatedEmployeeDto.Salary.HasValue)
                employee.Salary = updatedEmployeeDto.Salary.Value;

            _context.SaveChanges();
            return "Employee was updated successfully!";
        }
        public List<Employee> GetAllEmployees()
        {
            return _context.Employees.ToList();
        }
        public Employee? GetEmployeeById(int Id)
        {
            return _context.Employees.FirstOrDefault(e => e.Id == Id);
        }
        public string? DeleteEmployeeById(int Id)
        {
            var employeeToDelete = _context.Employees.FirstOrDefault(e => e.Id == Id);
            if (employeeToDelete == null)
            {
                return null;
            }
            _context.Employees.Remove(employeeToDelete);
            _context.SaveChanges();

            return "The employee was deleted successfully!";
        }
    }
}
