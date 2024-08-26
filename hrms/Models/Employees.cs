using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace hrms.Models
{
    public class Employees
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateOnly JoiningDate { get; set; }
        public int halfDays { get; set; }
        public int personalLeaves { get; set; }
        public int sickLeaves { get; set;  }
        public int compOffs { get; set; }

        // Use string for date keys
        public string AttendanceRecordsJson { get; set; }

        [NotMapped]
        public Dictionary<string, bool> AttendanceRecords
        {
            get => string.IsNullOrEmpty(AttendanceRecordsJson)
                ? new Dictionary<string, bool>()
                : JsonSerializer.Deserialize<Dictionary<string, bool>>(AttendanceRecordsJson);
            set => AttendanceRecordsJson = JsonSerializer.Serialize(value);
        }
    }
}
