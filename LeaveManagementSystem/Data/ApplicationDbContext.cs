using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUsers>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<ApplicationUsers> ApplicationUsers { get; set; }

        public DbSet<LeaveAllocation> LeaveAllocations{ get; set; }

        public DbSet<Period> Periods { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var administrator = new IdentityRole("Administrator");
            administrator.NormalizedName = "Administrator";

            var employee = new IdentityRole("Employee");
            employee.NormalizedName = "Employee";

            var supervisor = new IdentityRole("Supervisor");
            supervisor.NormalizedName = "Supervisor";


            builder.Entity<IdentityRole>().HasData(administrator, supervisor, employee);
        }
    }
}
