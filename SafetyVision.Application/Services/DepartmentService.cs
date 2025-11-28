using AutoMapper;
using SafetyVision.Application.DTOs.Departments;
using SafetyVision.Application.Interfaces;
using SafetyVision.Core.Entities;
using SafetyVision.Core.Enums;
using SafetyVision.Core.Interfaces;
using SafetyVision.Core.Utils;

namespace SafetyVision.Application.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DepartmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<DepartmentDto>> CreateAsync(PostDepartmentDto dto, CancellationToken cancellationToken = default)
        {
            if (await _unitOfWork.Departments.FirstOrDefaultAsync(d => d.Name == dto.Name, cancellationToken) is not null)
                return Result<DepartmentDto>.Failure(ErrorType.Conflict, $"A department with the name '{dto.Name}' already exists.");

            var department = _mapper.Map<Department>(dto);

            await _unitOfWork.Departments.AddAsync(department);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<DepartmentDto>.Success(_mapper.Map<DepartmentDto>(department));
        }

        public async Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var department = await _unitOfWork.Departments.GetByIdAsync(id, cancellationToken);
            if (department == null)
                return Result.Failure(ErrorType.NotFound, $"Department with ID '{id}' was not found.");

            // Check for workers
            var hasWorkers = (await _unitOfWork.Workers
                .FindAsync(w => w.DepartmentId == id, cancellationToken)).Any();
            if (hasWorkers)
                return Result.Failure(ErrorType.Conflict,
                    $"Cannot delete department '{department.Name}' because it has workers assigned to it. Please reassign or remove all workers before deleting this department.");

            _unitOfWork.Departments.Delete(department);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }

        public async Task<Result<IEnumerable<DepartmentDto>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var departments = await _unitOfWork.Departments.GetAllWithWorkersCountAsync(cancellationToken);

            return Result<IEnumerable<DepartmentDto>>.Success(_mapper.Map<IEnumerable<DepartmentDto>>(departments));
        }

        public async Task<Result<DepartmentDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var department = await _unitOfWork.Departments.GetByIdWithWorkersCount(id, cancellationToken);
            return department is null 
                ? Result<DepartmentDto>.Failure(ErrorType.NotFound, $"Department with ID '{id}' was not found.") 
                : Result<DepartmentDto>.Success(_mapper.Map<DepartmentDto>(department));
        }


        public async Task<Result> UpdateAsync(Guid id, PostDepartmentDto dto, CancellationToken cancellationToken = default)
        {
            var department = await _unitOfWork.Departments.GetByIdAsync(id, cancellationToken);
            if (department == null) 
                return Result.Failure(ErrorType.NotFound, $"Department with ID '{id}' was not found.");

            var existingWithSameName = await _unitOfWork.Departments
                .FirstOrDefaultAsync(d => d.Name == dto.Name && d.Id != id, cancellationToken);
            if (existingWithSameName is not null)
                return Result.Failure(ErrorType.Conflict, $"A department with the name '{dto.Name}' already exists. Please choose a different name.");

            _mapper.Map(dto, department);

            _unitOfWork.Departments.Update(department);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
