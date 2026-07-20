using Microsoft.AspNetCore.Mvc;
using ShiftsLogger.Interfaces;
using ShiftsLogger.Models;

namespace ShiftsLogger.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShiftsLoggerController : ControllerBase
    {
        private readonly IShiftService _shiftsService;

        public ShiftsLoggerController(IShiftService shiftService)
        {
            _shiftsService = shiftService;
        }
        [HttpPost]
        public ActionResult<string> CreateNewShift(Shift shift)
        {
            return Ok(CreateNewShift(shift));
        }
        [HttpGet]
        public ActionResult<List<Shift>> GetAllShifts()
        {
            return Ok(_shiftsService.GetAllShifts());
        }

        [HttpGet]
        public ActionResult<Shift> GetShiftById(int Id)
        {
            return Ok(_shiftsService.GetShiftById(Id));
        }
        [HttpGet]
        public ActionResult<List<Shift>> GetShiftsByEmployeeId(int Id)
        {
            return Ok(_shiftsService.GetShiftsByEmployeeId(Id));
        }
        [HttpGet]
        public ActionResult<List<Shift>> GetShiftsByAreaName(string areaName)
        {
            return Ok(_shiftsService.GetShiftsByAreaName(areaName));
        }
        [HttpDelete] 
        public ActionResult DeleteShiftById(int Id)
        {
            return Ok(_shiftsService.DeleteShiftById(Id));
        }
    }
}
