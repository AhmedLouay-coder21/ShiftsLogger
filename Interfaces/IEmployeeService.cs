using ShiftsLogger.DTO;
using ShiftsLogger.Models;

namespace ShiftsLogger.Interfaces
{
    public interface IEmployeeService
    {
        public string? AddNewEmployee(Employee employee);
        public string? UpdateEmployeeById(int Id, UpdateEmployeeDto updateEmployee);
        public List<Employee> GetAllEmployees();
        public Employee? GetEmployeeById(int Id);
        public string? DeleteEmployeeById(int Id);
    }
}
