using AutoMapper;
using OlympGuide.Application.Features.SportField;
using OlympGuide.Application.Features.User;
using OlympGuide.Domain.Features.SportField;
using OlympGuide.Domain.Features.User;

namespace OlympGuide
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<SportFieldDto, SportFieldType>().ReverseMap();
            CreateMap<CreateUserInformations, UserProfile>().ReverseMap();
            CreateMap<UserProfile, UserProfileDto>().ReverseMap();
        }
    }
}
