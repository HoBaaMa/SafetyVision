using SafetyVision.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace SafetyVision.Application.DTOs.Notifications
{
    public class PostNotificationDto
    {
        [Required(ErrorMessage = "Worker ID is required.")]
        public Guid ReceiverWorkerId { get; set; }
        // Should be filled auto
        public Guid SenderOfficerId { get; set; }
        [StringLength(300, ErrorMessage = "{0} cannot exceed {1} characters.")]
        public string Message { get; set; } = string.Empty;

        [Required(ErrorMessage = "{0} is required.")]
        public required NotificationType Type { get; set; }
        public NotificationStatus Status { get; set; }
    }
}
