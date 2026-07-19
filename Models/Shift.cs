namespace ShiftsLogger.Models
{
    public class Shift
    {
        // One shift belongs to one employee
        public int Id { get; set; }

        //EmployeeId
        public int EmployeeId { get; set; }
        // shift time span (which should be calculated by StartDate - EndDate
        public TimeSpan Duration => EndDate - StartDate;
        // shift area
        public string? Area { get; set; }
        // shift start date
        public DateTime StartDate { get; set; }
        // shift end date
        public DateTime EndDate { get; set; }

        public Employee Employee { get; set; } = null!;
    }
}
