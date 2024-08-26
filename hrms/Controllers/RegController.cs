using hrms.Data;
using hrms.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace hrms.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RegController : Controller
    {
        private readonly hrmsDbContext _context;

        MainController mc = new MainController();

        public RegController(hrmsDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegRequest request)
        {
            if (request == null)
            {
                return BadRequest("User data is null");
            }

            if (await _context.Employees.AnyAsync(u => u.Username == request.Username || u.Id == request.Id))
            {
                return Conflict("User already exists");
            }

            var hashedpw = mc.HashPassword(request.Password);

            var user = new Employees
            {
                Id = request.Id,
                Username = request.Username,
                Password = hashedpw,
                Email = request.Email,
                Phone = request.Phone,
                JoiningDate = request.JoiningDate,
                halfDays = 0,
                personalLeaves = 0,
                sickLeaves = 0,
                compOffs = 0
            };

            _context.Employees.Add(user);
            _context.SaveChanges();


            return CreatedAtAction(nameof(Register), new { id = user.Id }, user);
        }

        public class UserRegRequest
        {
            [Required] public string Id { get; set; }
            [Required] public string Username { get; set; }
            [Required] public string Password { get; set; }
            [Required] public string Email { get; set; }
            [Required] public string Phone { get; set; }
            [Required] public DateOnly JoiningDate { get; set; }
        }
    }
}
