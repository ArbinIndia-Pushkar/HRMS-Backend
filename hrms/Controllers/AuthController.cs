using Microsoft.AspNetCore.Mvc;
using hrms.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using hrms.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace hrms.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly hrmsDbContext _context;

        MainController mc = new MainController();
        public AuthController(hrmsDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
        {
            var hashedpw = mc.HashPassword(request.Password);

            if (request == null || string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
            {
                return BadRequest("Invalid login request.");
            }

            var user = await _context.Employees
            .FirstOrDefaultAsync(u => u.Username == request.Username && mc.VerifyPassword(request.Password, hashedpw));

            if (user == null)
            {
                return Unauthorized("Invalid username or password.");
            }

            return Ok();
        }

        public class UserLoginRequest
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}
