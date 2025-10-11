using AutoMapper;
using SafetyVision.Application.DTOs.Departments;
using SafetyVision.Core.Entities;

namespace SafetyVision.Application.Mappings
{
    internal class DepartmentMappingProfile : Profile
    {
        public DepartmentMappingProfile()
        {
            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<PostDepartmentDto, Department>();
        }
    }
}
