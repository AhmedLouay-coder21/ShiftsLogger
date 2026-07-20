namespace ShiftsLogger.DTO
{
    public class UpdateShiftDto
    {
        public string? Area { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? EmployeeId { get; set; }
    }
}
