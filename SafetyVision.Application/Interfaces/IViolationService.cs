using SafetyVision.Application.DTOs.Violations;
using SafetyVision.Core.Utils;

namespace SafetyVision.Application.Interfaces
{
    public interface IViolationService
    {
        Task<Result<IEnumerable<ViolationDto>>> GetAllAsync();
        Task<Result<IEnumerable<ViolationDto>>> GetWorkerViolationsByIdAsync(Guid workerId);
        Task<Result<IEnumerable<ViolationDto>>> GetViolationsByDateAsync(DateTime occurredDate);
        Task<Result<ViolationDto>> GetByIdAsync(Guid id);
        Task<Result<ViolationDto>> CreateAsync(PostAddViolationDto dto);
        Task<Result> UpdateAsync(Guid id, PostUpdateViolationDto dto);
        Task<Result> DeleteAsync(Guid id);
    }
}
