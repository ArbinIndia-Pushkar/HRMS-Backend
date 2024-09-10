using hrms.Data;
using hrms.Models;
using Microsoft.AspNetCore.Mvc;

namespace hrms.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly hrmsDbContext _context;

        public EmployeeController(hrmsDbContext context)
        {
            _context = context;
        }

        [HttpGet("{employeeId}/getempolyeesbyid")]
        public async Task<IActionResult> GetEmployeesByID(string employeeId)
        {
            try
            {
                var employee = await _context.Employees.FindAsync(employeeId);
                if (employee == null)
                {
                    return NotFound($"Employee with ID {employeeId} not found.");
                }

                var response = new
                {
                    employee.Username,
                    employee.Email,
                    employee.JoiningDate,
                    employee.halfDays,
                    employee.Phone,
                    employee.personalLeaves,
                    employee.sickLeaves,
                    employee.compOffs
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{employeeId}/applyforleaves")]
        public async Task<IActionResult> ApplyLeavesbyID(string employeeId, [FromBody] LeavesRequest request)
        {
            try
            {
                var employee = await _context.Employees.FindAsync(employeeId);
                if (employee == null)
                {
                    return NotFound($"Employee not found.");
                }

                // Add the new values to the existing values in the database
                employee.halfDays += request.halfdays;
                employee.personalLeaves += request.personalleaves;
                employee.sickLeaves += request.sickleaves;
                employee.compOffs += request.compoffs;

                _context.Employees.Update(employee);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        public class LeavesRequest
        {
            public int halfdays { get; set; }
            public int personalleaves { get; set; }
            public int sickleaves { get; set; }
            public int compoffs { get; set; }
        }
    }
}
