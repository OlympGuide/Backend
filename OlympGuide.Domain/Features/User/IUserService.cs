namespace OlympGuide.Domain.Features.User
{
    public interface IUserService
    {
        /// <summary>
        /// Find user by passed indentifier. The identifier comes from the used authentication provider.
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        Task<Guid> GetUserId(string identifier);
        Task<UserProfile> GetUserProfile(Guid id);
        Task<UserProfile> GetUserProfile(string accessToken);
    }
}
