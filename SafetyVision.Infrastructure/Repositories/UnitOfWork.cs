using SafetyVision.Core.Interfaces;
using SafetyVision.Infrastructure.Data;

namespace SafetyVision.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IWorkerRepository Workers { get; }

        public IDepartmentRepository Departments { get; }

        public ISafetyOfficerRepository SafetyOfficers { get; }

        public IViolationRepository Violations { get; }

        public INotificationRepository Notifications { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Workers = new WorkerRepository(_context);
            Departments = new DepartmentRepository(_context);
            SafetyOfficers = new SafetyOfficerRepository(_context);
            Violations = new ViolationRepository(_context);
            Notifications = new NotificationRepository(_context);

        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
