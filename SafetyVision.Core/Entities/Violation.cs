using SafetyVision.Core.Enums;

namespace SafetyVision.Core.Entities
{
    public class Violation
    {
        public Guid Id { get; set; }
        public Guid WorkerId { get; set; }
        public ViolationType Type { get; set; }
        public string Description { get; set; } = string.Empty;
        public ViolationSeverity Severity { get; set; }
        public DateTime OccurredDate { get; set; }
        public ViolationStatus Status { get; set; } 
        public DateTime UpdatedAt { get; set; }
        public Worker Worker { get; set; } = null!;
    }
}
