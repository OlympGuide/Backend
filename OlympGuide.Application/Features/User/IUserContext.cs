namespace OlympGuide.Application.Features.User
{
    public interface IUserContext
    {
        string? GetTokenFromCurrentUser();
    }
}
