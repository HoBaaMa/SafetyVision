using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Violation>> GetViolationsByDateAsync(DateTime occurredDate)
        {
            return await _context.Violations.Where(v => v.OccurredDate == occurredDate).ToListAsync();
        }

        public async Task<IEnumerable<Violation>> GetWorkerViolationsByIdAsync(Guid workerId)
        {
            return await _context.Violations.Where(v => v.WorkerId == workerId).ToListAsync();
        }
    }
}
