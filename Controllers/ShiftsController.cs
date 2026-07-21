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

        [HttpPatch("{id}")]
        public ActionResult<string?> UpdateShiftById(int Id, UpdateShiftDto updatedShift)
        {
            return Ok(_shiftsService.UpdateShiftById(Id, updatedShift));
        }

        [HttpGet]
        public ActionResult<List<Shift>> GetAllShifts()
        {
            return Ok(_shiftsService.GetAllShifts());
        }

        [HttpGet("{id}")]
        public ActionResult<Shift> GetShiftById(int Id)
        {
            return Ok(_shiftsService.GetShiftById(Id));
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
        public ActionResult DeleteShiftById(int Id)
        {
            return Ok(_shiftsService.DeleteShiftById(Id));
        }
    }
}
