namespace OlympGuide.Domain.Features.User
{
    public interface IUserService
    {
        /// <summary>
        /// Find user by passed indentifier. The identifier comes from the used authentication provider.
        /// </summary>
        /// <param name="identifier"></param>
        /// <exception cref="InvalidOperationException">Thrown if there is not related token for the use.</exception>
        /// <returns></returns>
        Task<Guid> GetUserId(string identifier);

        /// <summary>
        /// Get user based on the current user context. the user context is injected via DI.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown if there is not related token for the use.</exception>
        /// <returns></returns>
        Task<Guid> GetCurrentUserIdFromUserContext();

        /// <summary>
        /// Get current user based on the current user context. the user context is injected via DI.
        /// </summary>
        /// <returns></returns>
        Task<UserProfile> GetCurrentUserFromUserContext();
        /// <summary>
        /// Check if user role has changed from the current user. if the user roles has been changed, it will be updated.
        /// </summary>
        /// <returns></returns>
        Task<UserProfile> UpdateUser();

        Task<UserProfile> GetUserProfile(Guid id);
        Task<UserProfile> GetUserProfile(string accessToken);
    }
}
