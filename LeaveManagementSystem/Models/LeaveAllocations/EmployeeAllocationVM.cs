using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.Models.LeaveAllocations
{
    public class EmployeeAllocationVM : EmployeeListVM
    {

        [Display(Name = "Date Birth")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date)]
        public DateOnly DateOfBirth { get; set; }

        public bool IsCompletedAllocation { get; set; }
        public List <LeaveAllocationVM> LeaveAllocations { get; set; }
    }
}
