using AutoMapper;
using SafetyVision.Application.DTOs.SafetyOfficers;
using SafetyVision.Application.Interfaces;
using SafetyVision.Core.Entities;
using SafetyVision.Core.Enums;
using SafetyVision.Core.Interfaces;
using SafetyVision.Core.Utils;

namespace SafetyVision.Application.Services
{
    public class SafetyOfficerService : ISafetyOfficerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SafetyOfficerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<SafetyOfficerDto>> CreateAsync(PostSafetyOfficerDto dto, CancellationToken cancellationToken = default)
        {
            var existingUser = (await _unitOfWork.SafetyOfficers.FindAsync(so => so.Username == dto.Username)).Any();
            if (existingUser)
                return Result<SafetyOfficerDto>.Failure(ErrorType.Conflict, $"Username: {dto.Username} already exists.");

            var existingEmail = (await _unitOfWork.SafetyOfficers.FindAsync(so => so.Email == dto.Email)).Any();
            if (existingEmail)
                return Result<SafetyOfficerDto>.Failure(ErrorType.Conflict, $"Email: {dto.Email} already registered.");

            var safetyOfficer = _mapper.Map<SafetyOfficer>(dto);

            await _unitOfWork.SafetyOfficers.AddAsync(safetyOfficer);
            await _unitOfWork.SaveChangesAsync();

            return Result<SafetyOfficerDto>.Success(_mapper.Map<SafetyOfficerDto>(safetyOfficer));
        }

        public async Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var safetyOfficer = await _unitOfWork.SafetyOfficers.GetByIdAsync(id);
            if (safetyOfficer is null) 
                return Result.Failure(ErrorType.NotFound, $"Safety officer with ID: {id} not found.");

            _unitOfWork.SafetyOfficers.Delete(safetyOfficer);
            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }

        public async Task<Result<IEnumerable<SafetyOfficerDto>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var safetyOfficers = await _unitOfWork.SafetyOfficers.GetAllAsync();

            return Result<IEnumerable<SafetyOfficerDto>>.Success(_mapper.Map<IEnumerable<SafetyOfficerDto>>(safetyOfficers));
        }

        public async Task<Result<IEnumerable<SafetyOfficerDto>>> GetAllByRoleTitleAsync(string roleTitle, CancellationToken cancellationToken = default)
        {
            var safetyOfficers = await _unitOfWork.SafetyOfficers.GetAllAsync();
            safetyOfficers = safetyOfficers.Where(r => r.RoleTitle == roleTitle);

            return Result<IEnumerable<SafetyOfficerDto>>.Success(_mapper.Map<IEnumerable<SafetyOfficerDto>>(safetyOfficers));
        }

        public async Task<Result<SafetyOfficerDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var safetyOfficer = await _unitOfWork.SafetyOfficers.GetByIdAsync(id);

            if (safetyOfficer is null) 
                return Result<SafetyOfficerDto>.Failure(ErrorType.NotFound, $"Safety officer with ID: {id} not found.");

            return Result<SafetyOfficerDto>.Success(_mapper.Map<SafetyOfficerDto>(safetyOfficer));
        }

        public async Task<Result<SafetyOfficerDto>> GetByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            var safetyOfficer = await _unitOfWork.SafetyOfficers.GetByNameAsync(name);

            if (safetyOfficer is null) 
                return Result<SafetyOfficerDto>.Failure(ErrorType.NotFound, $"Safety officer with name: {name} not found.");

            return Result<SafetyOfficerDto>.Success(_mapper.Map<SafetyOfficerDto>(safetyOfficer));
        }

        public async Task<Result<SafetyOfficerDto>> GetByUserNameAsync(string username, CancellationToken cancellationToken = default)
        {
            var safetyOfficer = await _unitOfWork.SafetyOfficers.GetByUserNameAsync(username);

            if (safetyOfficer is null)
                return Result<SafetyOfficerDto>.Failure(ErrorType.NotFound, $"Safety officer with username: {username} not found.");

            return Result<SafetyOfficerDto>.Success(_mapper.Map<SafetyOfficerDto>(safetyOfficer));
        }

        public async Task<Result> UpdateAsync(Guid id, PostSafetyOfficerDto dto, CancellationToken cancellationToken = default)
        {
            var safetyOfficer = await _unitOfWork.SafetyOfficers.GetByIdAsync(id);

            if (safetyOfficer is null)
                return Result.Failure(ErrorType.NotFound, $"Safety officer with ID: {id} not found.");

            // Check if username is taken by another user (exclude self)
            var existingUser = (await _unitOfWork.SafetyOfficers.FindAsync(so => so.Username == dto.Username && so.Id != id)).Any();
            if (existingUser)
                return Result<SafetyOfficerDto>.Failure(ErrorType.Conflict, $"Username {dto.Username} already exists.");

            // Check if email is taken by another user (exclude self)
            var existingEmail = (await _unitOfWork.SafetyOfficers.FindAsync(so => so.Email == dto.Email && so.Id != id)).Any();
            if (existingEmail)
                return Result<SafetyOfficerDto>.Failure(ErrorType.Conflict, $"Email: {dto.Email} already registered.");

            _mapper.Map(dto, safetyOfficer);

            _unitOfWork.SafetyOfficers.Update(safetyOfficer);
            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }
    }
}
