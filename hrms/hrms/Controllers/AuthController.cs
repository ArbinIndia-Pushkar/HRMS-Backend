using Microsoft.AspNetCore.Mvc;
using hrms.hrms.Models;

namespace hrms.hrms.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginRequest request)
        {
            if (request.Username == HardcodedUsers.AdminUser.Username &&
                request.Password == HardcodedUsers.AdminUser.Password)
            {
                var token = GenerateJwtToken();  // Implement JWT token generation if needed
                return Ok(new { Token = token });
            }

            return Unauthorized();
        }

        private string GenerateJwtToken()
        {
            // Implement JWT token generation logic
            return "generated_jwt_token";
        }
    }
    public class UserLoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
