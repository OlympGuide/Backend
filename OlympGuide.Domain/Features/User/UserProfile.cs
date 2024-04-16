using OlympGuide.Domain.Abstraction;

namespace OlympGuide.Domain.Features.User
{
    /// <summary>
    /// Represents a user profile entity with authentication and personal details.
    /// </summary>
    public class UserProfile: Entity
    {
        public string Email { get; init; } = string.Empty;
        public string Name { get; init; } = string.Empty;
        public string DisplayName { get; init; } = string.Empty;
        public List<UserRole> Roles { get; init; } = new();
    }
}
