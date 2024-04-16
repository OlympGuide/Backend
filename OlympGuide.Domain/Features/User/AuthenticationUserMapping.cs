using System.ComponentModel.DataAnnotations;

namespace OlympGuide.Domain.Features.User
{
    public class AuthenticationUserMapping
    {
        [Key]
        public int Id { get; init; }
        public Guid UserId { get; init; } 
        public required string AuthenticationProviderId { get; init; }
    }
}
