using Microsoft.AspNetCore.Mvc;
using ShiftsLogger.Data;
using ShiftsLogger.Models;

namespace ShiftsLogger.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShiftsLoggerController : ControllerBase
    {
        private readonly ShiftsLoggerDbContext _context;

        public ShiftsLoggerController(ShiftsLoggerDbContext context)
        {
            _context = context;
        }
    }
}
