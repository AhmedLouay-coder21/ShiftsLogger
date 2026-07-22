using Microsoft.EntityFrameworkCore;
using ShiftsLogger.Data;
using ShiftsLogger.DTO;
using ShiftsLogger.Interfaces;
using ShiftsLogger.Models;

namespace ShiftsLogger.Services
{
    public class ShiftsService : IShiftService
    {
        private readonly ShiftsLoggerDbContext _context;
        public ShiftsService(ShiftsLoggerDbContext context)
        {
            _context = context;
        }
        public string? CreateNewShift(Shift shift)
        {
            if(shift == null)
            {
                return "An error has occurred, The shift was not created!";
            }
            var employeeExists = _context.Employees.Any(e => e.Id == shift.EmployeeId);

            if (!employeeExists)
            {
                return "Employee not found.";
            }

            _context.Shifts.Add(shift);
			_context.SaveChanges();

			return "Shift was created successfully!";
        }
		public string UpdateShiftById(int id, UpdateShiftDto updatedShiftDto)
		{
			var shift = _context.Shifts.FirstOrDefault(s => s.Id == id);

			if (shift == null)
			{
				return "An error has occurred. The shift was not found!";
			}

			if (updatedShiftDto.Area != null)
				shift.Area = updatedShiftDto.Area;

			if (updatedShiftDto.StartDate.HasValue)
				shift.StartDate = updatedShiftDto.StartDate.Value;

			if (updatedShiftDto.EndDate.HasValue)
				shift.EndDate = updatedShiftDto.EndDate.Value;

            if (updatedShiftDto.EmployeeId.HasValue)
            {
                var employeeExists = _context.Employees.Any(e => e.Id == updatedShiftDto.EmployeeId.Value);

                if (!employeeExists)
                {
                    return "Employee not found.";
                }

                shift.EmployeeId = updatedShiftDto.EmployeeId.Value;
            }

            _context.SaveChanges();

			return "Shift was updated successfully!";
		}
		public List<Shift> GetAllShifts()
        {
            return _context.Shifts.Include(s => s.Employee).ToList();
        }
        public Shift? GetShiftById(int Id)
        {
            return _context.Shifts.Include(s => s.Employee).FirstOrDefault(s => s.Id == Id);
        }
        public List<Shift> GetShiftsByEmployeeId(int Id)
        {
            return _context.Shifts
                    .Where(s => s.EmployeeId == Id)
                    .Include(s => s.Employee)
                    .ToList();
        }
        public List<Shift> GetShiftsByAreaName(string areaName)
        {
            return _context.Shifts.Where(s => s.Area == areaName)
				    .Include(s => s.Employee)
					.ToList();
        }
        public string? DeleteShiftById(int Id)
        {
            var shift = _context.Shifts.FirstOrDefault(s => s.Id == Id);
            if(shift == null)
            {
                return null;
            }
            _context.Shifts.Remove(shift);
			_context.SaveChanges();

			return "The shift was deleted successfully!";
        }
    }
}
