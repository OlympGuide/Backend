using Microsoft.EntityFrameworkCore;
using OlympGuide.Domain.Features.User;

namespace OlympGuide.Infrastructre.Repositories
{
    public class UserRepository(OlympGuideDbContext context) : IUserRepository
    {
        private readonly OlympGuideDbContext _context = context;
        public async Task<UserProfile> AddUser(UserProfile user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public Task AddUserIdentifierMapping(AuthenticationUserMapping userMapping)
        {
            _context.AuthenticationUserMappings.Add(userMapping);
            return _context.SaveChangesAsync();
        }

        public async Task<UserProfile> GetById(Guid id)
        {
            var existingUser = await _context.Users.SingleAsync(u => u.Id == id);
            if (existingUser == null)
                throw new UserNotFoundException(id);

            return existingUser;
        }

        public async Task<UserProfile> GetByIdentifier(string identifier)
        {

            var mapping = await _context.AuthenticationUserMappings.SingleAsync(u => u.AuthenticationProviderId == identifier);
            if (mapping == null)
                throw new UserNotFoundException(identifier);
            return await _context.Users.SingleAsync(u => u.Id.Equals(mapping.UserId));
        }

        public async Task<Guid> GetUserIdByAuthenticationProviderIdentifier(string identifier)
        {
            var mapping = await _context.AuthenticationUserMappings.SingleAsync(u => u.AuthenticationProviderId == identifier);
            if (mapping == null)
                throw new UserNotFoundException(identifier);
            return mapping.UserId;
        }

        public async Task<UserProfile> UpdateUser(UserProfile user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
