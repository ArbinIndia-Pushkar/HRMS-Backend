using hrms.Data;
using Microsoft.AspNetCore.Mvc;

namespace hrms.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttendanceController : ControllerBase
    {
        private readonly hrmsDbContext _context;

        public AttendanceController(hrmsDbContext context)
        {
            _context = context;
        }


        [HttpPost("{employeeId}/attendance")]
        public async Task<IActionResult> UpdateAttendance(string employeeId, [FromBody] Dictionary<string, bool> attendanceRecords)
        {
            try
            {
                var employee = await _context.Employees.FindAsync(employeeId);
                if (employee == null)
                {
                    return NotFound($"Employee with ID {employeeId} not found.");
                }

                employee.AttendanceRecords = attendanceRecords;
                await _context.SaveChangesAsync();

                return NoContent(); // 204 No Content
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{employeeId}/attendance")]
        public async Task<IActionResult> GetAttendance(string employeeId)
        {
            try
            {
                var employee = await _context.Employees.FindAsync(employeeId);
                if (employee == null)
                {
                    return NotFound($"Employee with ID {employeeId} not found.");
                }

                return Ok(employee.AttendanceRecords);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
