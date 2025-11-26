using AutoMapper;
using SafetyVision.Application.DTOs.SafetyOfficers;
using SafetyVision.Core.Entities;

namespace SafetyVision.Application.Mappings
{
    internal class SafetyOfficerMappingProfile : Profile
    {
        public SafetyOfficerMappingProfile()
        {
            CreateMap<SafetyOfficerDto, SafetyOfficer>().ReverseMap();
            CreateMap<PostSafetyOfficerDto, SafetyOfficer>();
        }
    }
}
