using ShiftsLogger.Models;

namespace ShiftsLogger.Data.Seeding
{
    public static class DbSeeder
    {
        public static void Seed(ShiftsLoggerDbContext context)
        {
            EmployeeSeeder.Seed(context);
            context.SaveChanges();

            ShiftSeeder.Seed(context);
            context.SaveChanges();
        }
    }
}
