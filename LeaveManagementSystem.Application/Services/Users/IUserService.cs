using LeaveManagementSystem.Data;

namespace LeaveManagementSystem.Application.Services.Users
{
    public interface IUserService
    {
        Task<List<ApplicationUsers>> GetEmployees();
        Task<ApplicationUsers> GetLoggedInUser();
        Task<ApplicationUsers> GetUserById(string userId);
    }
}