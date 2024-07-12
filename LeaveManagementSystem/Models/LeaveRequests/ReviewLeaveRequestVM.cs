using LeaveManagementSystem.Models.LeaveAllocations;
using LeaveManagementSystem.Services.LeaveRequests;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.Models.LeaveRequests
{
    public class ReviewLeaveRequestVM : LeaveRequestReadOnlyVM
    {
        public EmployeeListVM Employee { get; set; } = new EmployeeListVM();

        [DisplayName("Additional Information")]
        public string RequestComments { get; set; }

    }
}