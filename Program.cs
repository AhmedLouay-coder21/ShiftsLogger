
using Microsoft.EntityFrameworkCore;
using ShiftsLogger.Data;
using ShiftsLogger.Interfaces;
using ShiftsLogger.Services;

namespace ShiftsLogger
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            // Database connection setup
            builder.Services.AddDbContext<ShiftsLoggerDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Connection string"
            + "'DefaultConnection' not found.")));
            builder.Services.AddScoped<IShiftService, ShiftsService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
