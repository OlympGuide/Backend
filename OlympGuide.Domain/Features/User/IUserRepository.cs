namespace OlympGuide.Domain.Features.User
{
    public interface IUserRepository
    {

        Task<UserProfile> GetById(Guid id);
        Task<UserProfile> GetByIdentifier(string identifier);
        Task<UserProfile> AddUser(UserProfile user);
        Task AddUserIdentifierMapping(AuthenticationUserMapping userMapping);
        Task<Guid> GetUserIdByAuthenticationProviderIdentifier(string identifier);
        Task<UserProfile> UpdateUser(UserProfile user);
    }
}
