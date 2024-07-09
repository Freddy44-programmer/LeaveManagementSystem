using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.Data
{
    public class LeaveType : BaseEntity
    {
    

        [MaxLength(100)]
        public string Name { get; set; }

        [Display(Name = "Maximum Allocation of Days")]
        public int NumberOfDays { get; set; }

        public List<LeaveAllocation>? LeaveAllocations { get; set; }

    }
}
