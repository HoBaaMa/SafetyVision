using SafetyVision.Core.Entities;
using SafetyVision.Core.Enums;

namespace SafetyVision.Application.DTOs.Notifications
{
    public class NotificationDto
    {
        public Guid Id { get; set; }
        //public Guid ReciverWorkerId { get; set; }
        //public Guid SenderOfficerId { get; set; }
        public string Message { get; set; } = string.Empty;
        public NotificationType Type { get; set; }
        public NotificationStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public Worker Worker { get; set; } = null!;
        public SafetyOfficer SafetyOfficer { get; set; } = null!;
    }
}
