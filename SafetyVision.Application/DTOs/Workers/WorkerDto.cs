using SafetyVision.Core.Entities;
using SafetyVision.Core.Enums;

namespace SafetyVision.Application.DTOs.Workers
{
    public class WorkerDto
    {
        public Guid Id { get; set; }
        public required string Username { get; set; }
        public required string FullName { get; set; }
        public Gender Gender { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid DepartmentId { get; set; }
        public ICollection<Violation>? Violations;
    }
}
