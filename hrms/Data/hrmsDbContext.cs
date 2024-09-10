using Microsoft.EntityFrameworkCore;
using hrms.Models;

namespace hrms.Data
{
    public class hrmsDbContext : DbContext
    {
        public hrmsDbContext(DbContextOptions<hrmsDbContext> options) : base(options)
        {
        }

        public DbSet<Employees> Employees { get; set; }
    }
}
