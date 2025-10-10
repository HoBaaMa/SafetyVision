using SafetyVision.Core.Enums;

namespace SafetyVision.Core.Entities
{
    public class Notification
    {
        public int Id { get; set; }
        public int ReciverWorkerId { get; set; }
        public int SenderOfficerId { get; set; }
        public string Message { get; set; } = string.Empty;
        public NotificationType Type { get; set; }
        public NotificationStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
