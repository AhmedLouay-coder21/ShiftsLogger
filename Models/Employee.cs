using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ShiftsLogger.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string? FirstName { get; set; } = "";

        [Required]
        [MaxLength(50)]
        public string? LastName { get; set; } = "";

        [Required]
        public string? Role { get; set; } = "";

        [Range(0, 100000)]
        public int? Salary { get; set; }

        [JsonIgnore]
        public ICollection<Shift> Shifts { get; } = new List<Shift>(); // Collection navigation containing dependents
    }
}
