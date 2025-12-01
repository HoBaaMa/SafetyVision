using SafetyVision.Core.Entities;
using System.Threading;

namespace SafetyVision.Core.Interfaces
{
    public interface IWorkerRepository : IRepository<Worker>
    {
        Task<Worker?> GetByUserNameAsync(string username, CancellationToken cancellationToken = default);
        Task<Worker?> GetByNameAsync(string name, CancellationToken cancellationToken = default);
        
    }
}
