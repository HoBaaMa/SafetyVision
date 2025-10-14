using SafetyVision.Core.Entities;

namespace SafetyVision.Application.DTOs.Departments
{
    public class DepartmentDto
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<Worker> Workers { get; set; } = null!;
    }
}
