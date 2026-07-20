using System.Text.Json.Serialization;

namespace ShiftsLogger.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Role { get; set; }
        public int Salary { get; set; }

        [JsonIgnore]
        public ICollection<Shift> Shifts { get; } = new List<Shift>(); // Collection navigation containing dependents
    }
}
