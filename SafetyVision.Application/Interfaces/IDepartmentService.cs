using SafetyVision.Application.DTOs.Departments;
using SafetyVision.Core.Utils;

namespace SafetyVision.Application.Interfaces
{
    public interface IDepartmentService
    {
        Task<Result<IEnumerable<DepartmentDto>>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Result<DepartmentDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<DepartmentDto>> CreateAsync(PostDepartmentDto dto, CancellationToken cancellationToken = default);
        Task<Result> UpdateAsync(Guid id, PostDepartmentDto dto, CancellationToken cancellationToken = default);
        Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
