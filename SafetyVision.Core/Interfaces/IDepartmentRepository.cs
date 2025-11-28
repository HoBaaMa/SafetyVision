using SafetyVision.Core.Entities;

namespace SafetyVision.Core.Interfaces
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        Task<IEnumerable<Department>> GetAllWithWorkersCountAsync(CancellationToken cancellationToken = default);
        Task<Department?> GetByIdWithWorkersCount(Guid id, CancellationToken cancellationToken = default);
    }
}
