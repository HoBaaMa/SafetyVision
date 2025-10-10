using Microsoft.EntityFrameworkCore;
using SafetyVision.Core.Entities;
using SafetyVision.Core.Interfaces;
using SafetyVision.Infrastructure.Data;

namespace SafetyVision.Infrastructure.Repositories
{
    public class SafetyOfficerRepository : Repository<SafetyOfficer>, ISafetyOfficerRepository
    {
        public SafetyOfficerRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<SafetyOfficer?> GetByNameAsync(string name) => await _context.SafetyOfficers.FirstOrDefaultAsync(so => so.FullName.Contains(name));

        public async Task<SafetyOfficer?> GetByUserNameAsync(string username) => await _context.SafetyOfficers.FirstOrDefaultAsync(so => so.Username == username);
    }
}
