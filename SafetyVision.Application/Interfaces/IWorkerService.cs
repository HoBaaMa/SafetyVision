using SafetyVision.Application.DTOs.Workers;
using SafetyVision.Core.Entities;
using SafetyVision.Core.Utils;

namespace SafetyVision.Application.Interfaces
{
    public interface IWorkerService
    {
        Task<Result<WorkerDto>> GetByUserNameAsync(string username);
        Task<Result<WorkerDto>> GetByNameAsync(string name);
        Task<Result<IEnumerable<WorkerDto>>> GetByDepartmentIdAsync(Guid departmentId);

        Task<Result<IEnumerable<WorkerDto>>> GetAllAsync();
        Task<Result<WorkerDto>> GetByIdAsync(Guid id);
        Task<Result<WorkerDto>> CreateAsync(PostWorkerDto dto);
        Task<Result> UpdateAsync(Guid id, PostWorkerDto dto);
        Task<Result> DeleteAsync(Guid id);
    }
}
