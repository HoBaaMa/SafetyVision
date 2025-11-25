using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SafetyVision.Core.Enums;

namespace SafetyVision.Application.DTOs.Violations
{
    public class PostAddViolationDto
    {
        [DisplayName("Worker ID")]
        [Required(ErrorMessage = "{0}, is required.")]
        public Guid WorkerId { get; set; }
        public ViolationType Type { get; set; }
        [StringLength(500, ErrorMessage = "{0} cannot exceed {1} characters.")]
        public string Description { get; set; } = string.Empty;
        public ViolationSeverity Severity { get; set; }
        // Fluent Vildation for the occurred date must be not less than DateTime.UtcNow
        public DateTime OccurredDate { get; set; }
        [Required(ErrorMessage = "{0} is required.")]
        public ViolationStatus Status { get; set; }
    }
}
