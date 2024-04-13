using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympGuide.Domain.Features.User
{
    public interface IUserRepository
    {
        Task<UserProfile> GetById(Guid id);
        Task<UserProfile> GetByToken(string token);
        Task<UserProfile> AddUser(UserProfile user);
        Task<UserProfile> UpdateUser(UserProfile user);
    }
}
