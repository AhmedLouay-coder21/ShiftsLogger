using Microsoft.AspNetCore.Mvc;
using ShiftsLogger.DTO;
using ShiftsLogger.Interfaces;
using ShiftsLogger.Models;

namespace ShiftsLogger.Controllers
{
    [ApiController]
    [Route("api/shifts")]
    public class ShiftsController : ControllerBase
    {
        private readonly IShiftService _shiftsService;

        public ShiftsController(IShiftService shiftService)
        {
            _shiftsService = shiftService;
        }

        [HttpPost]
        public ActionResult<string> CreateNewShift(Shift shift)
        {
            return Ok(_shiftsService.CreateNewShift(shift));
        }

        [HttpPatch("{Id}")]
        public ActionResult<string?> UpdateShiftById(int Id, UpdateShiftDto updatedShift)
        {
            return Ok(_shiftsService.UpdateShiftById(Id, updatedShift));
        }

        [HttpGet]
        public ActionResult<List<Shift>> GetAllShifts()
        {
            return Ok(_shiftsService.GetAllShifts());
        }

        [HttpGet("{Id}")]
        public ActionResult<Shift> GetShiftById(int Id)
        {
            var shift = _shiftsService.GetShiftById(Id);

            if (shift == null)
                return NotFound();

            return Ok(shift);
        }

        [HttpGet("employee/{Id}")]
        public ActionResult<List<Shift>> GetShiftsByEmployeeId(int Id)
        {
            return Ok(_shiftsService.GetShiftsByEmployeeId(Id));
        }

        [HttpGet("area/{areaName}")]
        public ActionResult<List<Shift>> GetShiftsByAreaName(string areaName)
        {
            return Ok(_shiftsService.GetShiftsByAreaName(areaName));
        }

        [HttpDelete("{Id}")]
        public ActionResult<string?> DeleteShiftById(int Id)
        {
            var result = _shiftsService.DeleteShiftById(Id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
