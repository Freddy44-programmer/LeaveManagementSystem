using AutoMapper;
using LeaveManagementSystem.Data;
using LeaveManagementSystem.Models.LeaveAllocations;
using LeaveManagementSystem.Models.LeaveTypes;
using LeaveManagementSystem.Models.Periods;

namespace LeaveManagementSystem.MappingProfiles
{
    public class LeaveAllocationAutoMapperProfile : Profile
    {

        public LeaveAllocationAutoMapperProfile()
        {
            CreateMap<LeaveAllocation, LeaveAllocationVM>();
            CreateMap<LeaveAllocation, LeaveAllocationEditVM>();
            CreateMap<ApplicationUsers, EmployeeListVM>();
            CreateMap<Period, PeriodVM>();
            
        }
    }
}
