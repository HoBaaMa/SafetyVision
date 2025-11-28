namespace SafetyVision.Application.DTOs.Departments
{
    public class DepartmentDto
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public int WorkersCount { get; set; }
    }
}
