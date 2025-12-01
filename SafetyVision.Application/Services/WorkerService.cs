using AutoMapper;
using SafetyVision.Application.DTOs.Workers;
using SafetyVision.Application.Interfaces;
using SafetyVision.Core.Entities;
using SafetyVision.Core.Enums;
using SafetyVision.Core.Interfaces;
using SafetyVision.Core.Utils;

namespace SafetyVision.Application.Services
{
    public class WorkerService : IWorkerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public WorkerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<WorkerDto>> CreateAsync(PostWorkerDto dto, CancellationToken cancellationToken = default)
        {
            var existingUser = await _unitOfWork.Workers.GetByUserNameAsync(dto.Username, cancellationToken);
            if (existingUser is not null) 
                return Result<WorkerDto>.Failure(ErrorType.Conflict, $"A worker with the username '{dto.Username}' already exists. Please choose a different username.");

            var existingEmail = (await _unitOfWork.Workers.FindAsync(w => w.Email == dto.Email, cancellationToken)).Any();
            if (existingEmail) 
                return Result<WorkerDto>.Failure(ErrorType.Conflict, $"A worker with the email address '{dto.Email}' is already registered. Please use a different email address.");

            var department = await _unitOfWork.Departments.GetByIdAsync(dto.DepartmentId, cancellationToken);
            if (department is null) 
                return Result<WorkerDto>.Failure(ErrorType.NotFound, $"Department with ID '{dto.DepartmentId}' was not found. Please select a valid department.");

            var worker = _mapper.Map<Worker>(dto);
            worker.CreatedAt = DateTime.UtcNow;

            await _unitOfWork.Workers.AddAsync(worker, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<WorkerDto>.Success(_mapper.Map<WorkerDto>(worker));
        }

        public async Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var worker = await _unitOfWork.Workers.GetByIdAsync(id, cancellationToken);

            if (worker is null) 
                return Result.Failure(ErrorType.NotFound, $"Worker with ID '{id}' was not found.");

            bool hasViolations = worker.Violations?.Count > 0;
            if (hasViolations)
                return Result.Failure(ErrorType.Conflict, $"Cannot delete worker '{worker.FullName}' because they have {worker.Violations!.Count} existing violation(s). Please resolve or remove all violations before deleting this worker.");

            _unitOfWork.Workers.Delete(worker);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }

        public async Task<Result<IEnumerable<WorkerDto>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var workers = await _unitOfWork.Workers.GetAllAsync(cancellationToken);

            return Result<IEnumerable<WorkerDto>>.Success(_mapper.Map<IEnumerable<WorkerDto>>(workers));
        }

        public async Task<Result<IEnumerable<WorkerDto>>> GetByDepartmentIdAsync(Guid departmentId, CancellationToken cancellationToken = default)
        {
            var department = await _unitOfWork.Departments.GetByIdAsync(departmentId, cancellationToken);
            if (department is null) 
                return Result<IEnumerable<WorkerDto>>.Failure(ErrorType.NotFound, $"Department with ID '{departmentId}' was not found.");

            var workers = await _unitOfWork.Workers.FindAsync(w => w.DepartmentId == departmentId, cancellationToken);

            return Result<IEnumerable<WorkerDto>>.Success(_mapper.Map<IEnumerable<WorkerDto>>(workers));
        }

        public async Task<Result<WorkerDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var worker = await _unitOfWork.Workers.GetByIdAsync(id, cancellationToken);
            if (worker is null)
                return Result<WorkerDto>.Failure(ErrorType.NotFound, $"Worker with ID '{id}' was not found.");

            return Result<WorkerDto>.Success(_mapper.Map<WorkerDto>(worker));
        }

        public async Task<Result<WorkerDto>> GetByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            var worker = await _unitOfWork.Workers.GetByNameAsync(name, cancellationToken);

            if (worker is null) 
                return Result<WorkerDto>.Failure(ErrorType.NotFound, $"Worker with the name '{name}' was not found.");

            return Result<WorkerDto>.Success(_mapper.Map<WorkerDto>(worker));
        }

        public async Task<Result<WorkerDto>> GetByUserNameAsync(string username, CancellationToken cancellationToken = default)
        {
            var worker = await _unitOfWork.Workers.GetByUserNameAsync(username, cancellationToken);

            if (worker is null)
                return Result<WorkerDto>.Failure(ErrorType.NotFound, $"Worker with the username '{username}' was not found.");

            return Result<WorkerDto>.Success(_mapper.Map<WorkerDto>(worker));
        }

        public async Task<Result> UpdateAsync(Guid id, PostWorkerDto dto, CancellationToken cancellationToken = default)
        {
            var worker = await _unitOfWork.Workers.GetByIdAsync(id, cancellationToken);
            if (worker is null)
                return Result.Failure(ErrorType.NotFound, $"Worker with ID '{id}' was not found.");

            var existingUser = (await _unitOfWork.Workers.FindAsync(w => w.Username == dto.Username && w.Id != id, cancellationToken)).Any();
            if (existingUser) 
                return Result.Failure(ErrorType.Conflict, $"A worker with the username '{dto.Username}' already exists. Please choose a different username.");

            var existingEmail = (await _unitOfWork.Workers.FindAsync(w => w.Email == dto.Email && w.Id != id, cancellationToken)).Any();
            if (existingEmail) 
                return Result.Failure(ErrorType.Conflict, $"A worker with the email address '{dto.Email}' is already registered. Please use a different email address.");

            var department = await _unitOfWork.Departments.GetByIdAsync(dto.DepartmentId, cancellationToken);
            if (department is null)
                return Result.Failure(ErrorType.NotFound, $"Department with ID '{dto.DepartmentId}' was not found. Please select a valid department.");

            _mapper.Map(dto, worker);
            worker.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.Workers.Update(worker);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
