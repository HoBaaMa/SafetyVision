namespace SafetyVision.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IWorkerRepository Workers { get; }
        IDepartmentRepository Departments { get; }
        ISafetyOfficerRepository SafetyOfficers { get; }
        IViolationRepository Violations { get; }
        INotificationRepository Notifications { get; }
        Task<int> SaveChangesAsync();
    }
}
