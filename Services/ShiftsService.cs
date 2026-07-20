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
                return "An error has occured, The shift was not created!";
            }
            _context.Shifts.Add(shift);
			_context.SaveChanges();

			return "Shift was created successfully!";
        }
		public string UpdateShiftById(int id, UpdateShiftDto updatedShift)
		{
			var shift = _context.Shifts.FirstOrDefault(s => s.Id == id);

			if (shift == null)
			{
				return "An error has occurred. The shift was not found!";
			}

			if (updatedShift.Area != null)
				shift.Area = updatedShift.Area;

			if (updatedShift.StartDate.HasValue)
				shift.StartDate = updatedShift.StartDate.Value;

			if (updatedShift.EndDate.HasValue)
				shift.EndDate = updatedShift.EndDate.Value;

			if (updatedShift.EmployeeId.HasValue)
				shift.EmployeeId = updatedShift.EmployeeId.Value;

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
                return "Error, Shift Id was not found!";
            }
            _context.Shifts.Remove(shift);
			_context.SaveChanges();

			return "The shift was deleted successfully!";
        }
    }
}
