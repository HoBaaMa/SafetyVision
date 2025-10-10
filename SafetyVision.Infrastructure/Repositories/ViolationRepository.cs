using SafetyVision.Core.Entities;
using SafetyVision.Core.Interfaces;
using SafetyVision.Infrastructure.Data;

namespace SafetyVision.Infrastructure.Repositories
{
    public class ViolationRepository : Repository<Violation>, IViolationRepository
    {
        public ViolationRepository(AppDbContext context) : base(context)
        {
        }

        public Task<IEnumerable<Violation>> GetViolationsByDateAsync(DateTime occurredDate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Violation>> GetWorkerViolationsByIdAsync(int workerId)
        {
            throw new NotImplementedException();
        }
    }
}
