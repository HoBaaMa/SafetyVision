using Microsoft.EntityFrameworkCore.Storage;
using SafetyVision.Core.Interfaces;
using SafetyVision.Infrastructure.Data;

namespace SafetyVision.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IDbContextTransaction? _transaction;
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

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            await _transaction!.CommitAsync();
            await _transaction.DisposeAsync();
        }

        public async Task RollbackAsync()
        {
            await _transaction!.RollbackAsync();
            await _transaction.DisposeAsync();
        }
    }
}
