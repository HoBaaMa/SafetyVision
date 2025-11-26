using SafetyVision.Core.Enums;

namespace SafetyVision.Core.Entities
{
    public class Notification
    {
        public Guid Id { get; set; }

        // Receiver (worker)
        public Guid ReceiverWorkerId { get; set; }
        public Worker ReceiverWorker { get; set; } = null!;

        // Sender (officer)
        public Guid SenderOfficerId { get; set; }
        public SafetyOfficer SenderOfficer { get; set; } = null!;

        public string Message { get; set; } = string.Empty;

        public NotificationType Type { get; set; }
        public NotificationStatus Status { get; set; }

        public DateTime CreatedAt { get; set; } 

    }
}
