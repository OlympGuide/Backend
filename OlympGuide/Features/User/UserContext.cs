using OlympGuide.Application.Features.User;

namespace OlympGuide.Features.User
{
    public class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        public string? GetTokenFromCurrentUser()
        {
            return _httpContextAccessor.HttpContext?.Request.Headers.Authorization.FirstOrDefault()?.Split(" ").Last();
        }
    }
}
