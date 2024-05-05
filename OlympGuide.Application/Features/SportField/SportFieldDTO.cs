using OlympGuide.Domain.Features.SportField;

namespace OlympGuide.Application.Features.SportField
{
    public record SportFieldDto(Guid Id, string Name, string Description, double Longitude, double Latitude, string Address, SportFieldCategory Category);
}
