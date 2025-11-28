namespace SafetyVision.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IWorkerRepository Workers { get; }
        IDepartmentRepository Departments { get; }
        ISafetyOfficerRepository SafetyOfficers { get; }
        IViolationRepository Violations { get; }
        INotificationRepository Notifications { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
