using SafetyVision.Core.Entities;

namespace SafetyVision.Application.DTOs.SafetyOfficers
{
    public class SafetyOfficerDto
    {
        public Guid Id { get; set; }
        public required string FullName { get; set; }
        public required string Username { get; set; }
        // public required string Email { get; set; }
        public required string RoleTitle { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<Notification>? Notifications { get; set; }
    }
}
