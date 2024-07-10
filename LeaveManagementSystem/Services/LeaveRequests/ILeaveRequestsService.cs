﻿using LeaveManagementSystem.Models.LeaveRequests;

namespace LeaveManagementSystem.Services.LeaveRequests
{
    public interface ILeaveRequestsService
    {

        Task CreateLeaveRequest(LeaveRequestCreateVM model);
        Task <EmployeeLeaveRequestListVm> GetEmployeeLeaveRequests();
        Task <LeaveRequestListVM> GetAllLeaveRequests();
        Task CancelLeaveRequest(int leaveRequestId);
        Task ReviewLeaveRequest(ReviewLeaveRequestVM model);

        Task<bool> RequestDatesExceedAllocation (LeaveRequestCreateVM model);

    }
}