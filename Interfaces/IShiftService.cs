using ShiftsLogger.Models;

namespace ShiftsLogger.Interfaces
{
    public interface IShiftService
    {
        public string? CreateNewShift(Shift shift);
        public List<Shift> GetAllShifts();
        public Shift? GetShiftById(int Id);
        public List<Shift> GetShiftsByEmployeeId(int Id);
        public List<Shift> GetShiftsByAreaName(string areaName);
        public string? DeleteShiftById(int Id);
    }
}
