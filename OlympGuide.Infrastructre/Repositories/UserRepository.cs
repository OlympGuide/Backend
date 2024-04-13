using Microsoft.EntityFrameworkCore;
using OlympGuide.Domain.Features.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

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

        public Task<UserProfile> GetById(Guid id)
        {

           return _context.Users.SingleAsync(u => u.Id == id);
        }

        public Task<UserProfile> GetByToken(string token)
        {
            return _context.Users.SingleAsync(u => u.AccessToken == token);
        }

        public async Task<UserProfile> UpdateUser(UserProfile user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
