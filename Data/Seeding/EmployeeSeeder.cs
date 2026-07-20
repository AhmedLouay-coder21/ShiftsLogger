using ShiftsLogger.Models;

namespace ShiftsLogger.Data.Seeding
{
    public class EmployeeSeeder
    {
        public static void Seed(ShiftsLoggerDbContext context)
        {
            if (context.Employees.Any())
                return;

            context.Employees.AddRange(
                new Employee { FirstName = "Max", LastName = "Verstappen", Role = "Doctor", Salary = 10000  },
                new Employee { FirstName = "Sara", LastName = "Williams", Role = "Nurse", Salary = 5000 }
            );
        }
    }
}
