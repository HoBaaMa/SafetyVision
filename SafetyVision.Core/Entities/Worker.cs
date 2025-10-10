namespace SafetyVision.Core.Entities
{
    public class Worker : User
    {
        public Guid DepartmentId { get; set; }
        public Department Department { get; set; } = null!;
        public ICollection<Violation>? Violations;
    }
}
