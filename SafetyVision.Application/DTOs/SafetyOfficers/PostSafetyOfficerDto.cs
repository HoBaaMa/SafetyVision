using SafetyVision.Core.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SafetyVision.Application.DTOs.SafetyOfficers
{
    public class PostSafetyOfficerDto
    {
        [DisplayName("Full Name")]
        [Required(ErrorMessage = "{0} is required.")]
        [StringLength(150, ErrorMessage = "{0} cannot exceed {1} characters.")]
        public required string FullName { get; set; }
        
        [Required(ErrorMessage = "{0} is required.")]
        [StringLength(100, ErrorMessage = "{0} cannot exceed {1} characters.")]
        public required string Username { get; set; }
        
        [Required(ErrorMessage = "{0} is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public required string Email { get; set; }
        
        [DisplayName("Role Title")]
        [Required(ErrorMessage = "{0} is required.")]
        public required string RoleTitle { get; set; }
        
        [Required(ErrorMessage = "{0} is required.")]
        public Gender Gender { get; set; }
        
        [Required(ErrorMessage = "{0} is required.")]
        public UserRole Role { get; set; }
    }
}
