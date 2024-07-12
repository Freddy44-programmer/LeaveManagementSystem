﻿using LeaveManagementSystem.Application.Models.LeaveAllocations;
using LeaveManagementSystem.Data;

namespace LeaveManagementSystem.Application.Services.LeaveAllocations
{
    public interface ILeaveAllocationsService
    {
        Task AllocateLeave(string employeeId);
        Task<EmployeeAllocationVM> GetEmployeeAllocations(string? userId);
        Task<LeaveAllocationEditVM> GetEmployeeAllocation(int allocationId);
        Task<List<EmployeeListVM>> GetEmployees();
        Task EditAllocation(LeaveAllocationEditVM allocationEditVM);

        Task<LeaveAllocation> GetCurrentAllocation(int leaveTypeId, string employeeId);

    }

}