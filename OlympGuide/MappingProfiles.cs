using AutoMapper;
using OlympGuide.Application.Features.Reservation;
using OlympGuide.Application.Features.SportField;
using OlympGuide.Application.Features.SportFieldProposal;
using OlympGuide.Application.Features.User;
using OlympGuide.Domain.Features.Reservation;
using OlympGuide.Domain.Features.SportField;
using OlympGuide.Domain.Features.SportFieldProposal;
using OlympGuide.Domain.Features.User;

namespace OlympGuide
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<SportFieldDto, SportFieldType>().ReverseMap();
            CreateMap<SportFieldProposalDetailsDto, SportFieldProposalType>().ReverseMap();
            CreateMap<CreateUserInformations, UserProfile>().ReverseMap();
            CreateMap<UserProfile, UserProfileDto>().ReverseMap();
            CreateMap<ReservationDetailsDto, ReservationType>().ReverseMap();
        }
    }
}
