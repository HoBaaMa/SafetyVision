namespace SafetyVision.Core.Entities
{
    public class Department
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<Worker> Workers { get; set; } = null!;
    }
}
