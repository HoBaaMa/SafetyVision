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
        public async Task<Result<WorkerDto>> CreateAsync(PostWorkerDto dto)
        {
            var existingUser = await _unitOfWork.Workers.GetByUserNameAsync(dto.Username);
            if (existingUser is not null) 
                return Result<WorkerDto>.Failure(ErrorType.Conflict, "Username already exists.");

            var existingEmail = (await _unitOfWork.Workers.FindAsync(w => w.Email == dto.Email)).Any();
            if (existingEmail) 
                return Result<WorkerDto>.Failure(ErrorType.Conflict, "Email already registered.");

            var department = await _unitOfWork.Departments.GetByIdAsync(dto.DepartmentId);
            if (department is null) 
                return Result<WorkerDto>.Failure(ErrorType.NotFound, "Invalid department ID.");

            var worker = _mapper.Map<Worker>(dto);

            await _unitOfWork.Workers.AddAsync(worker);
            await _unitOfWork.SaveChangesAsync();

            return Result<WorkerDto>.Success(_mapper.Map<WorkerDto>(worker));
        }

        public async Task<Result> DeleteAsync(Guid id)
        {
            var worker = await _unitOfWork.Workers.GetByIdAsync(id);

            if (worker is null) 
                return Result.Failure(ErrorType.NotFound, "Worker not found.");

            if (worker.Violations?.Count != 0)
                return Result.Failure(ErrorType.Conflict, "Cannot delete worker with existing violations.");
            

            _unitOfWork.Workers.Delete(worker);
            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }

        public async Task<Result<IEnumerable<WorkerDto>>> GetAllAsync()
        {
            var workers = await _unitOfWork.Workers.GetAllAsync();

            return Result<IEnumerable<WorkerDto>>.Success(_mapper.Map<IEnumerable<WorkerDto>>(workers));
        }

        public async Task<Result<IEnumerable<WorkerDto>>> GetByDepartmentIdAsync(Guid departmentId)
        {
            var department = await _unitOfWork.Departments.GetByIdAsync(departmentId);
            if (department is null) 
                return Result<IEnumerable<WorkerDto>>.Failure(ErrorType.NotFound, "Invalid department ID.");

            var workers = await _unitOfWork.Workers.FindAsync(w => w.DepartmentId == departmentId);
            

            return Result<IEnumerable<WorkerDto>>.Success(_mapper.Map<IEnumerable<WorkerDto>>(workers));
        }

        public async Task<Result<WorkerDto>> GetByIdAsync(Guid id)
        {
            var worker = await _unitOfWork.Workers.GetByIdAsync(id);
            if (worker is null)
                return Result<WorkerDto>.Failure(ErrorType.NotFound, "Worker not found.");


            return Result<WorkerDto>.Success(_mapper.Map<WorkerDto>(worker));
        }

        public async Task<Result<WorkerDto>> GetByNameAsync(string name)
        {
            var worker = await _unitOfWork.Workers.GetByNameAsync(name);

            if (worker is null) 
                return Result<WorkerDto>.Failure(ErrorType.NotFound, "Worker not found.");

            return Result<WorkerDto>.Success(_mapper.Map<WorkerDto>(worker));
        }

        public async Task<Result<WorkerDto>> GetByUserNameAsync(string username)
        {
            var worker = await _unitOfWork.Workers.GetByUserNameAsync(username);

            if (worker is null) return Result<WorkerDto>.Failure(ErrorType.NotFound, "Worker not found.");

            return Result<WorkerDto>.Success(_mapper.Map<WorkerDto>(worker));
        }

        public async Task<Result> UpdateAsync(Guid id, PostWorkerDto dto)
        {
            var worker = await _unitOfWork.Workers.GetByIdAsync(id);
            if (worker is null)
                return Result.Failure(ErrorType.NotFound, "Worker not found.");

            var existingUser = (await _unitOfWork.Workers.FindAsync(w => w.Username == dto.Username && w.Id != id)).Any();
            if (existingUser) 
                return Result.Failure(ErrorType.Conflict, "Username already exists.");

            var existingEmail = (await _unitOfWork.Workers.FindAsync(w => w.Email == dto.Email && w.Id != id)).Any();
            if (existingEmail) 
                return Result.Failure(ErrorType.Conflict, "Email already registered.");

            if (await _unitOfWork.Departments.GetByIdAsync(dto.DepartmentId) is null)
                return Result.Failure(ErrorType.NotFound, "Invalid department ID.");

            _mapper.Map(dto, worker);

            _unitOfWork.Workers.Update(worker);
            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }
    }
}
