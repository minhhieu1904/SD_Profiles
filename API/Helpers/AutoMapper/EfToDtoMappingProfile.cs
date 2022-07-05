using API.Dtos;
using API.Models;
using AutoMapper;

namespace API.Helpers.AutoMapper
{
    public class EfToDtoMappingProfile : Profile
    {
        public EfToDtoMappingProfile()
        {
            CreateMap<About, AboutDto>();
            CreateMap<Contact, ContactDto>();
            CreateMap<Faq, FaqDto>();
            CreateMap<Feature, FeatureDto>();
            CreateMap<Member, MemberDto>();
            CreateMap<Position, PositionDto>();
            CreateMap<Subscribe, SubscribeDto>();
            CreateMap<ApplicationUser, UserDto>();
            CreateMap<ApplicationRole, RoleDto>();
            CreateMap<Menu, MenuDto>();
        }
    }
}