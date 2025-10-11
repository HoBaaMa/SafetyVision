using SafetyVision.Core.Entities;
using SafetyVision.Core.Enums;

namespace SafetyVision.Core.Interfaces
{
    public interface INotificationRepository : IRepository<Notification>
    {
        Task<IEnumerable<Notification>> GetWorkerNotificationsByIdAsync(Guid workerId);
        Task<IEnumerable<Notification>> GetNotificationsByTypeAsync(NotificationType notificationType);
        Task<IEnumerable<Notification>> GetNotificationsByDateAsync(DateTime date);
    }
}
