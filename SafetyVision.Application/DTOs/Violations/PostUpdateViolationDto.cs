using SafetyVision.Core.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SafetyVision.Application.DTOs.Violations
{
    public class PostUpdateViolationDto
    {
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Description { get; set; } = string.Empty;
        public ViolationSeverity Severity { get; set; }
        [Required(ErrorMessage = "{0} is required.")]
        public ViolationStatus Status { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
