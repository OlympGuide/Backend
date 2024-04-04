using AutoMapper;
using OlympGuide.Application.Features.SportField;
using OlympGuide.Domain.Features.SportField;

public class MappingProfiles: Profile
{
    public MappingProfiles()
    {
        CreateMap<SportFieldDTO, SportFieldType>().ReverseMap();
    }
}