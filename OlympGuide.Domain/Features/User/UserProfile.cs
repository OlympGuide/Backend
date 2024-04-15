using OlympGuide.Domain.Abstraction;

namespace OlympGuide.Domain.Features.User
{
    /// <summary>
    /// Represents a user profile entity with authentication and personal details.
    /// </summary>
    public class UserProfile: Entity
    {
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public List<UserRole> Roles { get; set; } = new();
    }
}
