using SafetyVision.Application.DTOs.SafetyOfficers;
using SafetyVision.Core.Utils;

namespace SafetyVision.Application.Interfaces
{
    public interface ISafetyOfficerService
    {
        Task<Result<IEnumerable<SafetyOfficerDto>>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Result<IEnumerable<SafetyOfficerDto>>> GetAllByRoleTitleAsync(string roleTitle, CancellationToken cancellationToken = default);
        //Task<Result<PagedResult<SafetyOfficerDto>>> GetPagedAsync(int pageNumber, int pageSize, string? filterOn, string? filterQuery, string? sortBy, bool? isAscending = true);
        Task<Result<SafetyOfficerDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Result<SafetyOfficerDto>> GetByNameAsync(string name, CancellationToken cancellationToken = default);
        Task<Result<SafetyOfficerDto>> GetByUserNameAsync(string username, CancellationToken cancellationToken = default);
        Task<Result<SafetyOfficerDto>> CreateAsync(PostSafetyOfficerDto dto, CancellationToken cancellationToken = default);
        Task<Result> UpdateAsync(Guid id, PostSafetyOfficerDto dto, CancellationToken cancellationToken = default);
        Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
