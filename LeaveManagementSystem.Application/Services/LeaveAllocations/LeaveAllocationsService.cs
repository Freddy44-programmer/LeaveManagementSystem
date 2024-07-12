using AutoMapper;
using LeaveManagementSystem.Application.Models.LeaveAllocations;
using LeaveManagementSystem.Application.Services.Periods;
using LeaveManagementSystem.Application.Services.Users;
using LeaveManagementSystem.Data;

using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Application.Services.LeaveAllocations;

public class LeaveAllocationsService(ApplicationDbContext _context, IUserService _userService
      , IMapper _mapper, IPeriodsService _periodsService) : ILeaveAllocationsService
{
    public async Task AllocateLeave(string employeeId)
    {
        // get all the leave types
        var leaveTypes = await _context.LeaveTypes
        .Where(q => !q.LeaveAllocations.Any(m => m.EmployeeId == employeeId))
        .ToListAsync();

        // get the current period based on the year

        var period = await _periodsService.GetCurrentPeriod();
        var monthsRemaining = period.EndDate.Month - DateTime.Now.Month;

        // foreach leave type, create an allocation entry
        foreach (var leaveType in leaveTypes)
        {
            var accuralRate = decimal.Divide(leaveType.NumberOfDays, 12);
            var leaveAllocation = new LeaveAllocation
            {
                EmployeeId = employeeId,
                LeaveTypeId = leaveType.Id,
                PeriodId = period.Id,
                Days = (int)Math.Ceiling(accuralRate * monthsRemaining)
            };
            _context.Add(leaveAllocation);

        }
        await _context.SaveChangesAsync();
    }



    public async Task<EmployeeAllocationVM> GetEmployeeAllocations(string? userId)
    {
        var user = string.IsNullOrEmpty(userId)
             ? await _userService.GetLoggedInUser()
            : await _userService.GetUserById(userId);



        var allocations = await GetAllocations(user.Id);
        var allocationVmList = _mapper.Map<List<LeaveAllocation>, List<LeaveAllocationVM>>(allocations);
        var leavesTypesCount = await _context.LeaveTypes.CountAsync();
        var employeeVm = new EmployeeAllocationVM
        {
            DateOfBirth = user.DateOfBirth,
            Email = user.Email,
            Firstname = user.FirstName,
            Lastname = user.LastName,
            Id = user.Id,
            LeaveAllocations = allocationVmList,
            IsCompletedAllocation = leavesTypesCount == allocations.Count
        };
        return employeeVm;
    }


    public async Task<List<EmployeeListVM>> GetEmployees()
    {
        var users = await _userService.GetEmployees();
        var employees = _mapper.Map<List<ApplicationUsers>, List<EmployeeListVM>>(users.ToList());

        return employees;
    }

    public async Task<LeaveAllocationEditVM> GetEmployeeAllocation(int allocationId)
    {
        var allocation = await _context.LeaveAllocations
              .Include(r => r.LeaveType)
              .Include(r => r.Employee)
              .FirstOrDefaultAsync(r => r.Id == allocationId);

        var model = _mapper.Map<LeaveAllocationEditVM>(allocation);
        return model;
    }

    public async Task EditAllocation(LeaveAllocationEditVM allocationEditVM)
    {
        /*
      var leaveAllocation = await GetEmployeeAllocation(allocationEditVM.Id);
        if (leaveAllocation == null)
        {
            throw new Exception("Leave allocation record does not exist.");
        }
        leaveAllocation.Days = allocationEditVM.Days
        _context.Update(leaveAllocation);
        _context.Entry(leaveAllocation).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        */

        await _context.LeaveAllocations
             .Where(q => q.Id == allocationEditVM.Id)
             .ExecuteUpdateAsync(s => s.SetProperty(e => e.Days, allocationEditVM.Days));

    }


    public async Task<LeaveAllocation> GetCurrentAllocation(int leaveTypeId, string employeeId)
    {
        var period = await _periodsService.GetCurrentPeriod();
        var allocation = await _context.LeaveAllocations
                .FirstAsync(q => q.LeaveTypeId == leaveTypeId
                && q.EmployeeId == employeeId
                && q.PeriodId == period.Id);
        return allocation;
    }

    private async Task<List<LeaveAllocation>> GetAllocations(string? userId)
    {


        var period = await _periodsService.GetCurrentPeriod();
        var leaveAllocations = await _context.LeaveAllocations
            .Include(q => q.LeaveType)
            .Include(q => q.Period)
            .Where(q => q.EmployeeId == userId && q.PeriodId == period.Id)
            .ToListAsync();

        return leaveAllocations;
    }

    private async Task<bool> AllocationExists(string userId, int periodId, int LeaveTypeId)
    {
        var exists = await _context.LeaveAllocations.AnyAsync(
             q => q.EmployeeId == userId
             && q.LeaveTypeId == LeaveTypeId
             && q.PeriodId == periodId
            );

        return exists;
    }

}