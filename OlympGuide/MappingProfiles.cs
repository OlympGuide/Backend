using AutoMapper;
using OlympGuide.Application.Features.SportField;
using OlympGuide.Application.Features.SportFieldProposal;
using OlympGuide.Domain.Features.SportField;
using OlympGuide.Domain.Features.SportFieldProposal;

namespace OlympGuide
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<SportFieldDto, SportFieldType>().ReverseMap();
            CreateMap<SportFieldProposalDetailsDto, SportFieldProposalType>().ReverseMap();
        }
    }
}
