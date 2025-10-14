using AutoMapper;
using SafetyVision.Application.DTOs.Workers;
using SafetyVision.Core.Entities;

namespace SafetyVision.Application.Mappings
{
    internal class WorkerMappingProfile : Profile
    {
        public WorkerMappingProfile()
        {
            CreateMap<WorkerDto, Worker>().ReverseMap();
            CreateMap<PostWorkerDto, Worker>();
        }
    }
}
