using AutoMapper;
using LeaveManagementSystem.Data;
using LeaveManagementSystem.Models.LeaveTypes;

namespace LeaveManagementSystem.MappingProfiles
{
    public class LeaveTypeAutoMapperProfile : Profile
    {
        public LeaveTypeAutoMapperProfile() 
        {
            CreateMap<LeaveType, LeaveTypeReadOnlyVM>();

            CreateMap<LeaveTypeCreateVM, LeaveType>();

            CreateMap<LeaveTypeEditVM, LeaveType>().ReverseMap();
        }
    }
}
