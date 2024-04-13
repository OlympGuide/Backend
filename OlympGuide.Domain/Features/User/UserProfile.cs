using OlympGuide.Domain.Abstraction;

namespace OlympGuide.Domain.Features.User
{
    /// <summary>
    /// Represents a user profile entity with authentication and personal details.
    /// </summary>
    public class UserProfile: Entity
    {
        public string AccessToken { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public UserRole Role { get; set; }
    }
}
