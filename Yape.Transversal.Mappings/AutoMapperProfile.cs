using Yape.Application.DTOs;
using Yape.Domain.Entities;
using AutoMapper;

namespace Yape.Transversal.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<NotificationDto, Notification>().ReverseMap();
            CreateMap<EntityDto, Entity>().ReverseMap();
            CreateMap<NotificationTypeDto, NotificationType>().ReverseMap();
        }
    }
}
