using System.ComponentModel.DataAnnotations;

namespace SafetyVision.Application.DTOs.Departments
{
    public class PostDepartmentDto
    {
        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(100, ErrorMessage = "Maximum length for department name is {1}.")]
        public required string Name { get; set; }
    }
}
