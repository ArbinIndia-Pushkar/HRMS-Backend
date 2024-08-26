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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Ignore AttendanceRecords property
            modelBuilder.Entity<Employees>()
                .Ignore(e => e.AttendanceRecords);
        }
    }
}
