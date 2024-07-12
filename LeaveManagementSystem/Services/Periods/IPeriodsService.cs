using LeaveManagementSystem.Data;

namespace LeaveManagementSystem.Services.Periods
{
    public interface IPeriodsService
    {
        Task<Period> GetCurrentPeriod();
    }
}
