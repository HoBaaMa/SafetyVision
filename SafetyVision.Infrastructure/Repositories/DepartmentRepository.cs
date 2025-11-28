using Microsoft.EntityFrameworkCore;
using SafetyVision.Core.Entities;
using SafetyVision.Core.Interfaces;
using SafetyVision.Infrastructure.Data;

namespace SafetyVision.Infrastructure.Repositories
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Department>> GetAllWithWorkersCountAsync() => await _context.Departments
            .Include(w => w.Workers).ToListAsync();

        public async Task<Department?> GetByIdWithWorkersCount(Guid id) => await _context.Departments
            .AsNoTracking()
            .Include(w => w.Workers).FirstOrDefaultAsync(d => d.Id == id);
    }
}
