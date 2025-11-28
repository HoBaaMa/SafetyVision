using AutoMapper;
using SafetyVision.Application.DTOs.Departments;
using SafetyVision.Core.Entities;

namespace SafetyVision.Application.Mappings
{
    internal class DepartmentMappingProfile : Profile
    {
        public DepartmentMappingProfile()
        {
            CreateMap<Department, DepartmentDto>()
                .ForMember(dest => dest.WorkersCount,
                    opt => opt.MapFrom(src => src.Workers != null ? src.Workers.Count : 0)).ReverseMap();

            CreateMap<PostDepartmentDto, Department>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.Workers, opt => opt.Ignore());
        }
    }
}
