using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OlympGuide.Domain.Features.User;

namespace OlympGuide.Infrastructre.Repositories
{
    public class UserRepository(OlympGuideDbContext context, ILogger<UserRepository> logger) : IUserRepository
    {
        private readonly OlympGuideDbContext _context = context;
        private readonly ILogger _logger = logger;
        public async Task<UserProfile> AddUser(UserProfile user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task AddUserIdentifierMapping(AuthenticationUserMapping userMapping)
        {
            _context.AuthenticationUserMappings.Add(userMapping);
            await _context.SaveChangesAsync();
        }

        public async Task<UserProfile> GetById(Guid id)
        {
            try
            {
                return await _context.Users.FirstAsync(u => u.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError("User could not be found by id: " + ex.Source);
                throw new UserNotFoundException(id);
            }
        }

        public async Task<UserProfile> GetByIdentifier(string identifier)
        {
            try
            {
                var mapping = await _context.AuthenticationUserMappings.SingleAsync(u => u.AuthenticationProviderId == identifier);
                return await _context.Users.SingleAsync(u => u.Id.Equals(mapping.UserId));
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError("User mapping could not be found from token" + ex.Source);
                throw new UserNotFoundException(identifier);
            }           
        }

        public async Task<Guid> GetUserIdByAuthenticationProviderIdentifier(string identifier)
        {
            try
            {
                var mapping = await _context.AuthenticationUserMappings.SingleAsync(u => u.AuthenticationProviderId == identifier);
                return mapping.UserId;
            }
            catch(InvalidOperationException ex)
            {
                _logger.LogError("User mapping could not be found from authentication identifier" + ex.Source);
                throw new UserNotFoundException(identifier);
            }
            
        }

        public async Task<UserProfile> UpdateUser(UserProfile user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
