using SafetyVision.Core.Entities;

namespace SafetyVision.Core.Interfaces
{
    public interface IWorkerRepository : IRepository<Worker>
    {
        Task<Worker?> GetByUserNameAsync(string username);
        Task<Worker?> GetByNameAsync(string name);
        
    }
}
