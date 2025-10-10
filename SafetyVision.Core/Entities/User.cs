using SafetyVision.Core.Enums;

namespace SafetyVision.Core.Entities
{
    public abstract class User
    {
        public Guid Id { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public required string FullName { get; set; }
        public UserRole Role { get; set; } 
        public Gender Gender { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public ICollection<Notification>? Notifications { get; set; }
    }
}
