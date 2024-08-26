using BCrypt.Net;
using hrms.Data;

namespace hrms.Controllers
{
    public class MainController
    {
        private readonly hrmsDbContext _context;
        public string HashPassword(string password)
        {
            // Generate a salt and hash the password with a default work factor (10)
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            // Verify the password against the stored hash
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
