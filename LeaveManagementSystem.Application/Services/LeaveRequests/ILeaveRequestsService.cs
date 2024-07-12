﻿using LeaveManagementSystem.Application.Models.LeaveRequests;

namespace LeaveManagementSystem.Application.Services.LeaveRequests
{
    public interface ILeaveRequestsService
    {

        Task CreateLeaveRequest(LeaveRequestCreateVM model);
        Task<List<LeaveRequestReadOnlyVM>> GetEmployeeLeaveRequests();
        Task<EmployeeLeaveRequestListVM> AdminGetAllLeaveRequests();
        Task CancelLeaveRequest(int leaveRequestId);
        Task<bool> RequestDatesExceedAllocation(LeaveRequestCreateVM model);
        Task ReviewLeaveRequest(int leaveRequestId, bool approved);
        Task<ReviewLeaveRequestVM> GetLeaveRequestForReview(int id);
    }
}