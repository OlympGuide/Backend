namespace OlympGuide.Domain.Features.User
{
    public record CreateUserInformations(string Firstname, string Lastname, string DisplayName, string Email, List<UserRole> userRoles);
    
}
