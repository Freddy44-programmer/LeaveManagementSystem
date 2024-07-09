using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.Models.LeaveAllocations
{
    public class EmployeeListVM
    {
        public string Id { get; set; } = string.Empty;

        [Display(Name = "First Name")]
        public string Firstname { get; set; } = string.Empty ;

        [Display(Name = "Last Name")]
        public string Lastname { get; set; } = string.Empty ;

        [Display(Name = "Email Address")]
        public string Email { get; set; } = string.Empty;
    }
}
