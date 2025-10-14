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

        public async Task<Result<DepartmentDto>> CreateAsync(PostDepartmentDto dto)
        {
            if (await _unitOfWork.Departments.FirstOrDefaultAsync(d => d.Name == dto.Name) is not null)
                return Result<DepartmentDto>.Failure(ErrorType.Conflict, "Department already exists.");

            var department = _mapper.Map<Department>(dto);

            await _unitOfWork.Departments.AddAsync(department);
            await _unitOfWork.SaveChangesAsync();

            return Result<DepartmentDto>.Success(_mapper.Map<DepartmentDto>(department));
        }

        public async Task<Result> DeleteAsync(Guid id)
        {
            var department = await _unitOfWork.Departments.GetByIdAsync(id);
            if (department == null) return Result.Failure(ErrorType.NotFound ,"Department not found.");

            _unitOfWork.Departments.Delete(department);
            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }

        public async Task<Result<IEnumerable<DepartmentDto>>> GetAllAsync()
        {
            var departments = await _unitOfWork.Departments.GetAllAsync();

            return Result<IEnumerable<DepartmentDto>>.Success(_mapper.Map<IEnumerable<DepartmentDto>>(departments));
        }

        public async Task<Result<DepartmentDto>> GetByIdAsync(Guid id)
        {
            var department = await _unitOfWork.Departments.GetByIdAsync(id);
            return department is null ? Result<DepartmentDto>.Failure(ErrorType.NotFound, "Department not found.") : Result<DepartmentDto>.Success(_mapper.Map<DepartmentDto>(department));
        }


        public async Task<Result> UpdateAsync(Guid id, PostDepartmentDto dto)
        {
            var department = await _unitOfWork.Departments.GetByIdAsync(id);
            if (department == null) return Result.Failure(ErrorType.NotFound, "Department is not found.");

            if (await _unitOfWork.Departments.FirstOrDefaultAsync(d => d.Name == dto.Name) is not null && dto.Name != department.Name)
                return Result<DepartmentDto>.Failure(ErrorType.Conflict, "Department already exists.");

            _mapper.Map(dto, department);

            _unitOfWork.Departments.Update(department);
            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }
    }
}
