using System.ComponentModel.DataAnnotations;

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
        [Required]
        public string? Area { get; set; } = "";

        [Required]
        // shift start date
        public DateTime StartDate { get; set; }

        [Required]
        // shift end date
        public DateTime EndDate { get; set; }

        // foreign key
        public Employee Employee { get; set; } = null!;
    }
}
