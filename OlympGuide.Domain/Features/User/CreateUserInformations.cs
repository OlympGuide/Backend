namespace OlympGuide.Domain.Features.User
{
    public record CreateUserInformations(string UserIdentifier, string Name, string DisplayName, string Email, List<UserRole> Roles);
    
}
