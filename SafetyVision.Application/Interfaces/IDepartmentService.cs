using SafetyVision.Application.DTOs.Departments;
using SafetyVision.Core.Utils;

namespace SafetyVision.Application.Interfaces
{
    public interface IDepartmentService
    {
        Task<Result<IEnumerable<DepartmentDto>>> GetAllAsync();
        Task<Result<DepartmentDto>?> GetByIdAsync(Guid id);
        Task<Result<DepartmentDto>> CreateAsync(PostDepartmentDto dto);
        Task<Result> UpdateAsync(Guid id, PostDepartmentDto dto);
        Task<Result> DeleteAsync(Guid id);
    }
}
