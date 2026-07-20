using ShiftsLogger.Data;
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
            return "Shift was created successfully!";
        }
        public List<Shift> GetAllShifts()
        {
            return _context.Shifts.ToList();
        }
        public Shift? GetShiftById(int Id)
        {
            return _context.Shifts.FirstOrDefault(s => s.Id == Id);
        }
        public List<Shift> GetShiftsByEmployeeId(int Id)
        {
            return _context.Shifts
                    .Where(s => s.EmployeeId == Id)
                    .ToList();
        }
        public List<Shift> GetShiftsByAreaName(string areaName)
        {
            return _context.Shifts.Where(s => s.Area == areaName)
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
            return "The shift was deleted successfully!";
        }
    }
}
