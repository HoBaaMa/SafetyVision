using SafetyVision.Core.Enums;

namespace SafetyVision.Application.DTOs.Notifications
{
    public class PostNotificationDto
    {
        public Guid ReciverWorkerId { get; set; }
        public Guid SenderOfficerId { get; set; }
        public string Message { get; set; } = string.Empty;
        public NotificationType Type { get; set; }
        public NotificationStatus Status { get; set; }
    }
}
