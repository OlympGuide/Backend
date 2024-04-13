namespace OlympGuide.Domain.Features.User
{
    public interface IUserService
    {
        Task<UserProfile> GetUserProfile(Guid id);
        Task<UserProfile> GetUserProfile(string accessToken);
    }
}
