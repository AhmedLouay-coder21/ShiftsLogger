using ShiftsLogger.Models;

namespace ShiftsLogger.Data.Seeding
{
    public class ShiftSeeder
    {
        public static void Seed(ShiftsLoggerDbContext context)
        {
            if (context.Shifts.Any())
                return;

            context.Shifts.AddRange(
                new Shift { EmployeeId = 1, Area = "Spa", StartDate = new DateTime(2026, 7, 20, 20, 0, 0) , EndDate = new DateTime(2026, 7, 21, 8, 0, 0) },
                new Shift { EmployeeId = 2, Area = "Berlin", StartDate = new DateTime(2026, 7, 21, 8, 0, 0), EndDate = new DateTime(2026, 7, 21, 20, 0, 0) }
            );
        }
    }
}
