using SafetyVision.Core.Entities;

namespace SafetyVision.Core.Interfaces
{
    public interface ISafetyOfficerRepository : IRepository<SafetyOfficer>
    {
        Task<SafetyOfficer?> GetByUserNameAsync(string username);
        Task<SafetyOfficer?> GetByNameAsync(string name);
    }
}
