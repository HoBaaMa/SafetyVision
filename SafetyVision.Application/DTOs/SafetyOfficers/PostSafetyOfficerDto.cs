namespace SafetyVision.Application.DTOs.SafetyOfficers
{
    public class PostSafetyOfficerDto
    {
        public required string FullName { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string RoleTitle { get; set; }

    }
}
