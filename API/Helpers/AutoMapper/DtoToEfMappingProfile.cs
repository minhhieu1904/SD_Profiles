using API.Dtos;
using API.Models;
using AutoMapper;

namespace API.Helpers.AutoMapper
{
    public class DtoToEfMappingProfile : Profile
    {
        public DtoToEfMappingProfile()
        {
            CreateMap<AboutDto, About>();
            CreateMap<ContactDto, Contact>();
            CreateMap<FaqDto, Faq>();
            CreateMap<FeatureDto, Feature>();
            CreateMap<MemberDto, Member>();
            CreateMap<PositionDto, Position>();
            CreateMap<SubscribeDto, Subscribe>();
            CreateMap<MenuDto, Menu>();
        }
    }
}