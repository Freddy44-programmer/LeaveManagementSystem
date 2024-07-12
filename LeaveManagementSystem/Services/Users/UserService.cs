using LeaveManagementSystem.Common;
using LeaveManagementSystem.Data;
using Microsoft.AspNetCore.Identity;

namespace LeaveManagementSystem.Services.Users;

public class UserService(UserManager<ApplicationUsers> _userManager, IHttpContextAccessor _httpContextAccessor) : IUserService
{

    public async Task<ApplicationUsers> GetLoggedInUser()
    {
        var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User);
        return user;
    }

    public async Task<ApplicationUsers> GetUserById(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        return user;
    }

    public async Task<List<ApplicationUsers>> GetEmployees()
    {
        var employees = await _userManager.GetUsersInRoleAsync(Roles.Employee);
        return employees.ToList();
    }
}

