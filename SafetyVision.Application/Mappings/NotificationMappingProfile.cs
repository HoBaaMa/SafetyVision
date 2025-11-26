using AutoMapper;
using SafetyVision.Application.DTOs.Notifications;
using SafetyVision.Core.Entities;
namespace SafetyVision.Application.Mappings
{
    internal class NotificationMappingProfile : Profile
    {
        public NotificationMappingProfile()
        {
            CreateMap<Notification, NotificationDto>().ReverseMap();
            CreateMap<PostNotificationDto, Notification>();
        }
    }
}
