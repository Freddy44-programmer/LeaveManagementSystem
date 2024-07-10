using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagementSystem.Data.Configurations
{
    public class IdentityRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {

            var administrator = new IdentityRole("Administrator");
            administrator.NormalizedName = "Administrator";

            var employee = new IdentityRole("Employee");
            employee.NormalizedName = "Employee";

            var supervisor = new IdentityRole("Supervisor");
            supervisor.NormalizedName = "Supervisor";

            builder.HasData(administrator, supervisor, employee);
        }
    }
}
