using AutoMapper;
using LeaveManagementSystem.Data;
using LeaveManagementSystem.Models.LeaveRequests;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Services.LeaveRequests
{
    public class LeaveRequestsService(IMapper _mapper, UserManager<ApplicationUsers> _userManager,
        IHttpContextAccessor _httpContextAccessor, ApplicationDbContext _context) : ILeaveRequestsService
    {
        public Task CancelLeaveRequest(int leaveRequestId)
        {
            throw new NotImplementedException();
        }

        public async Task CreateLeaveRequest(LeaveRequestCreateVM model)
        {
            // map data to leave request data model
            var leaveRequest = _mapper.Map<LeaveRequest>(model);

            // get logged in employee id
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User);
            leaveRequest.EmployeeId = user.Id;

            // set LeaveRequestStatusId to pending
            leaveRequest.LeaveRequestStatusId = (int)LeaveRequestStatus.Pending;

            // save leave request
            _context.Add(leaveRequest);
         

            // deduct allocation days based on request
            var numberOfDays = model.EndDate.DayNumber - model.StartDate.DayNumber;
            var allocationToDeduct = await _context.LeaveAllocations
                .FirstAsync(m => m.LeaveTypeId == model.LeaveTypeId && m.EmployeeId == user.Id);

            allocationToDeduct.Days = allocationToDeduct.Days - numberOfDays;

            await _context.SaveChangesAsync();
        }

        public Task<LeaveRequestListVM> GetAllLeaveRequests()
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeLeaveRequestListVm> GetEmployeeLeaveRequests()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RequestDatesExceedAllocation( LeaveRequestCreateVM model)
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User);
            var numberOfDate = model.EndDate.DayNumber - model.StartDate.DayNumber;
            var allocation = await _context.LeaveAllocations
              .FirstAsync(m => m.LeaveTypeId == model.LeaveTypeId && m.EmployeeId == user.Id);

            return allocation.Days < numberOfDate;
        }

        public Task ReviewLeaveRequest(ReviewLeaveRequestVM model)
        {
            throw new NotImplementedException();
        }
    }
}
