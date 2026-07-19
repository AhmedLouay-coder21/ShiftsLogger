using Microsoft.AspNetCore.Mvc;
using ShiftsLogger.Data;

namespace ShiftsLogger.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShiftsLoggerController : ControllerBase
    {
        public class MyController
        {
            private readonly ShiftsLoggerDbContext _context;

            public MyController(ShiftsLoggerDbContext context)
            {
                _context = context;
            }
        }
    }
}
