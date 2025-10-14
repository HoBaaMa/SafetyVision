using Microsoft.EntityFrameworkCore;
using SafetyVision.Core.Entities;
using SafetyVision.Core.Interfaces;
using SafetyVision.Infrastructure.Data;

namespace SafetyVision.Infrastructure.Repositories
{
    public class WorkerRepository : Repository<Worker>, IWorkerRepository
    {
        public WorkerRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Worker>> GetByDepartmentIdAsync(Guid departmentId) => await _context.Workers.ToListAsync();

        public async Task<Worker?> GetByNameAsync(string name) => await _context.Workers.FirstOrDefaultAsync(w => w.FullName.Contains(name));

        public async Task<Worker?> GetByUserNameAsync(string username) => await _context.Workers.FirstOrDefaultAsync(w => w.Username == username);
    }
}