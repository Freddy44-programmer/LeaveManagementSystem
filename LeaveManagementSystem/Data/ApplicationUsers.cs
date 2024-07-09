using Microsoft.AspNetCore.Identity;

namespace LeaveManagementSystem.Data
{
    public class ApplicationUsers : IdentityUser
    {
     
        public string FirstName { get; set; } = "";

        public string LastName { get; set; } = "";

        public DateOnly DateOfBirth { get; set; }

        public DateTime CreatedAt { get; set; }

    }
    
    
}
