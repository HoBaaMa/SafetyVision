namespace SafetyVision.Application.DTOs.Workers
{
    public class PostWorkerDto
    {
        public required string FullName { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public Guid DepartmentId { get; set; }

    }
}
