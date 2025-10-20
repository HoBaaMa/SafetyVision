using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SafetyVision.Core.Enums;

namespace SafetyVision.Application.DTOs.Violations
{
    public class PostAddViolationDto
    {
        [DisplayName("Worker Id")]
        [Required(ErrorMessage = "{0}, is required.")]
        public Guid WorkerId { get; set; }
        public ViolationType Type { get; set; }
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Description { get; set; } = string.Empty;
        public ViolationSeverity Severity { get; set; }
        public DateTime OccurredDate { get; set; }
        [Required(ErrorMessage = "{0} is required.")]
        public ViolationStatus Status { get; set; }
    }
}
