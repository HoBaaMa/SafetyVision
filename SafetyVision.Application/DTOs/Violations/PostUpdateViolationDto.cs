using SafetyVision.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace SafetyVision.Application.DTOs.Violations
{
    public class PostUpdateViolationDto
    {
        [StringLength(500, ErrorMessage = "{0} cannot exceed {1} characters.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "{0} is required.")]
        public required ViolationSeverity Severity { get; set; }
        [Required(ErrorMessage = "{0} is required.")]
        public required ViolationStatus Status { get; set; }
    }
}
