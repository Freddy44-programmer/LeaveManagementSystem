using LeaveManagementSystem.Data;

namespace LeaveManagementSystem.Services.Users
{
    public interface IUserService
    {
        Task<List<ApplicationUsers>> GetEmployees();
        Task<ApplicationUsers> GetLoggedInUser();
        Task<ApplicationUsers> GetUserById(string userId);
    }
}