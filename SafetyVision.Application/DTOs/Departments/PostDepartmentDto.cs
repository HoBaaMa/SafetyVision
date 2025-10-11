using SafetyVision.Core.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SafetyVision.Application.DTOs.Departments
{
    public class PostDepartmentDto
    {
        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(100, ErrorMessage = "Max length is {1}.")]
        public required string Name { get; set; }
    }
}
