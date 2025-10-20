using AutoMapper;
using SafetyVision.Application.DTOs.Violations;
using SafetyVision.Core.Entities;

namespace SafetyVision.Application.Mappings
{
    internal class ViolationMappingProfile : Profile
    {
        public ViolationMappingProfile()
        {
            CreateMap<Violation, ViolationDto>().ReverseMap();
            CreateMap<PostAddViolationDto, Violation>();
            CreateMap<PostUpdateViolationDto, Violation>();
        }
    }
}
