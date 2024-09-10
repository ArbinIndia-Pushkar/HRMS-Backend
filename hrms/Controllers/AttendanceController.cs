using hrms.Data;
using hrms.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json;

namespace hrms.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttendanceController : Controller
    {
        private readonly hrmsDbContext _context;

        public AttendanceController(hrmsDbContext context)
        {
            _context = context;
        }

        [HttpGet("{employeeId}/attendance")]
        public async Task<IActionResult> GetAttendanceRecords(string employeeId)
        {
            var employee = await _context.Employees.FindAsync(employeeId);

            if (employee == null)
            {
                return NotFound();
            }

            var records = DeserializeAttendanceRecords(employee.AttendanceRecords);
            return Ok(records);
        }

        [HttpPost("{employeeId}")]
        public async Task<IActionResult> UpdateAttendanceRecords(string employeeId, [FromBody] Dictionary<string, bool> newAttendanceRecords)
        {
            var employee = await _context.Employees.FindAsync(employeeId);

            if (employee == null)
            {
                return NotFound();
            }

            var existingRecords = DeserializeAttendanceRecords(employee.AttendanceRecords);

            foreach (var record in newAttendanceRecords)
            {
                existingRecords[record.Key] = record.Value; // Update or add new records
            }

            employee.AttendanceRecords = SerializeAttendanceRecords(existingRecords);

            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private static string SerializeAttendanceRecords(Dictionary<string, bool> attendanceRecords)
        {
            var dates = attendanceRecords
                .Where(record => record.Value) // Only include attended dates
                .Select(record => record.Key);

            return string.Join(",", dates);
        }

        private static Dictionary<string, bool> DeserializeAttendanceRecords(string attendanceRecords)
        {
            var records = new Dictionary<string, bool>();

            if (!string.IsNullOrEmpty(attendanceRecords))
            {
                var dates = attendanceRecords.Split(',');
                foreach (var date in dates)
                {
                    records[date] = true; // Mark as attended
                }
            }

            return records;

        }
    }
}
