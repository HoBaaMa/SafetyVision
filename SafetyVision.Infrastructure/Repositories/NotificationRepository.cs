using SafetyVision.Core.Entities;
using SafetyVision.Core.Enums;
using SafetyVision.Core.Interfaces;
using SafetyVision.Infrastructure.Data;

namespace SafetyVision.Infrastructure.Repositories
{
    public class NotificationRepository : Repository<Notification>, INotificationRepository
    {
        public NotificationRepository(AppDbContext context) : base(context)
        {
        }

        public Task<IEnumerable<Notification>> GetNotificationsByDateAsync(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Notification>> GetNotificationsByTypeAsync(NotificationType notificationType)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Notification>> GetWorkerNotificationsByIdAsync(int workerId)
        {
            throw new NotImplementedException();
        }
    }
}
