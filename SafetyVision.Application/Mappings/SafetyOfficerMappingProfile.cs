using AutoMapper;
using SafetyVision.Application.DTOs.SafetyOfficers;
using SafetyVision.Core.Entities;

namespace SafetyVision.Application.Mappings
{
    internal class SafetyOfficerMappingProfile : Profile
    {
        public SafetyOfficerMappingProfile()
        {
            CreateMap<SafetyOfficer, SafetyOfficerDto>().ReverseMap();
            CreateMap<PostSafetyOfficerDto, SafetyOfficer>();
        }
    }
}
