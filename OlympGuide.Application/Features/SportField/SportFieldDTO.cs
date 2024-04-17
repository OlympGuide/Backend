namespace OlympGuide.Application.Features.SportField
{
    public record SportFieldDto(Guid Id, string Name, string Description, float Longitude, float Latitude, string Address);
}
