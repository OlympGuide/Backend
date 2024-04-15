using System.ComponentModel.DataAnnotations;

namespace OlympGuide.Domain.Features.User
{
    public class AuthenticationUserMapping()
    {
        [Key]
        public int Id { get; set; }
        public Guid UserId { get; set; } 
        public required string AuthenticationProviderId { get; set; }
    }
}
