using OlympGuide.Domain.Features.User;

namespace OlympGuide.Application.Features.User
{
    public record UserProfileDto(string Id, string Name, string DisplayName, List<UserRole> Roles);
}
