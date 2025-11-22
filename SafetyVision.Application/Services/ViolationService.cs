using AutoMapper;
using SafetyVision.Application.DTOs.Violations;
using SafetyVision.Application.Interfaces;
using SafetyVision.Core.Entities;
using SafetyVision.Core.Interfaces;
using SafetyVision.Core.Utils;
using SafetyVision.Core.Enums;

namespace SafetyVision.Application.Services
{
    public class ViolationService : IViolationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ViolationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<ViolationDto>> CreateAsync(PostAddViolationDto dto)
        {
            if (await _unitOfWork.Workers.FirstOrDefaultAsync(w => w.Id == dto.WorkerId) is null)
                return Result<ViolationDto>.Failure(ErrorType.NotFound, $"Worker with ID: {dto.WorkerId} not found.");

            var violation = _mapper.Map<Violation>(dto);
            violation.OccurredDate = DateTime.UtcNow;

            await _unitOfWork.Violations.AddAsync(violation);
            await _unitOfWork.SaveChangesAsync();

            return Result<ViolationDto>.Success(_mapper.Map<ViolationDto>(violation));
        }

        public async Task<Result> DeleteAsync(Guid id)
        {
            var violation = await _unitOfWork.Violations.GetByIdAsync(id);

            if (violation is null)
                return Result.Failure(ErrorType.NotFound, $"Violation with ID {id} not found.");

            _unitOfWork.Violations.Delete(violation);
            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }

        public async Task<Result<IEnumerable<ViolationDto>>> GetAllAsync()
        {
            var violations = await _unitOfWork.Violations.GetAllAsync();

            return Result<IEnumerable<ViolationDto>>.Success(_mapper.Map<IEnumerable<ViolationDto>>(violations));
        }

        public async Task<Result<ViolationDto>> GetByIdAsync(Guid id)
        {
            var violation = await _unitOfWork.Violations.GetByIdAsync(id);

            if (violation is null)
                return Result<ViolationDto>.Failure(ErrorType.NotFound, $"Violation with ID {id} not found.");

            return Result<ViolationDto>.Success(_mapper.Map<ViolationDto>(violation));
        }

        public async Task<Result<IEnumerable<ViolationDto>>>GetViolationsByDateAsync(DateTime occurredDate)
        {
            var violations = await _unitOfWork.Violations.GetViolationsByDateAsync(occurredDate);

            return Result<IEnumerable<ViolationDto>>.Success(_mapper.Map<IEnumerable<ViolationDto>>(violations));
        }

        public async Task<Result<IEnumerable<ViolationDto>>>GetWorkerViolationsByIdAsync(Guid workerId)
        {
            if (await _unitOfWork.Workers.GetByIdAsync(workerId) is null)
                return Result<IEnumerable<ViolationDto>>.Failure(ErrorType.NotFound, $"Worker with ID: {workerId} not found.");

            var violations = await _unitOfWork.Violations.GetWorkerViolationsByIdAsync(workerId);

            return Result<IEnumerable<ViolationDto>>.Success(_mapper.Map<IEnumerable<ViolationDto>>(violations));
        }

        public async Task<Result> UpdateAsync(Guid id, PostUpdateViolationDto dto)
        {
            var violation = await _unitOfWork.Violations.GetByIdAsync(id);
            if (violation is null)
                return Result<ViolationDto>.Failure(ErrorType.NotFound, $"Violation with ID {id} not found.");

            if (await _unitOfWork.Workers.FirstOrDefaultAsync(w => w.Id == violation.WorkerId) is null)
                return Result<ViolationDto>.Failure(ErrorType.NotFound, $"Worker with ID: {violation.WorkerId} not found.");


            _mapper.Map(dto, violation);
            violation.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.Violations.Update(violation);
            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }
    }
}
