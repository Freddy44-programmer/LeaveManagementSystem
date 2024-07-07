using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.Data
{
    public class LeaveType
    {
    
        public int Id {  get; set; }
        public string Name { get; set; }

        [Display(Name = "Number of Days")]
        public int NumberOfDays { get; set; }

    }
}
