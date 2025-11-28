using AutoMapper;
using SafetyVision.Application.DTOs.Departments;
using SafetyVision.Core.Entities;

namespace SafetyVision.Application.Mappings
{
    internal class DepartmentMappingProfile : Profile
    {
        public DepartmentMappingProfile()
        {
            CreateMap<Department, DepartmentDto>().ForMember(dest => dest.WorkersCount, opt => opt.MapFrom(src => src.Workers.Count)).ReverseMap();
            CreateMap<PostDepartmentDto, Department>();

        }
    }
}
