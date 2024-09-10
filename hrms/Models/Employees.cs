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
        public string AttendanceRecords { get; set; }

    }
}
