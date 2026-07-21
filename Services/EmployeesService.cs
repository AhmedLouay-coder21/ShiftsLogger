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
                return "An error has occured, The shift was not created!";
            }
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return "A new emplyee was added successfully";
        }
        public string? UpdateEmployeeById(int Id, UpdateEmployeeDto updatedEmployee)
        {
            var employee = _context.Employees.FirstOrDefault(s => s.Id == Id);

            if (employee == null)
            {
                return "An error has occurred. The employee was not added!";
            }
            if (updatedEmployee.FirstName != null)
                employee.FirstName = updatedEmployee.FirstName;

            if (updatedEmployee.LastName != null)
                employee.LastName = updatedEmployee.LastName;

            if (updatedEmployee.Role != null)
                employee.Role = updatedEmployee.Role;

            if (updatedEmployee.Salary != 0)
                employee.Salary = updatedEmployee.Salary;

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
                return "Error, Employee Id was not found!";
            }
            _context.Employees.Remove(employeeToDelete);
            _context.SaveChanges();

            return "The employee was deleted successfully!";
        }
    }
}
