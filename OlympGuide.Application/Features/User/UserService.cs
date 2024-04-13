using AutoMapper;
using Microsoft.Extensions.Logging;
using OlympGuide.Domain.Features.User;

namespace OlympGuide.Application.Features.User
{
    public class UserService(ILogger<UserService> logger, IUserRepository repository, IAuthenticationProvider authenticationProvider) : IUserService
    {
        private readonly ILogger<UserService> _logger = logger;
        private readonly IUserRepository _repository = repository;
        private readonly IAuthenticationProvider _authenticationProvider = authenticationProvider;
        private readonly IMapper _mapper;

        public async Task<UserProfile> GetUserProfile(Guid id)
        {
            var user = await _repository.GetById(id);
            if (user == null)
                throw new UserNotFoundException(id);
            return user;
        }

        public async Task<UserProfile> GetUserProfile(string accessToken)
        {
           var user = await _repository.GetByToken(accessToken);
            if (user == null)
            {
                try
                {
                    await CreateUserProfile(accessToken);
                    var user = await _repository.GetByToken(accessToken);

                }
                catch (UserNotFoundException ex)
                {

                }
                catch(InvalidCastException ex)
                {

                }


            }
        }

        public async Task<UserProfile> GetUserProfileByToken(string accessToken)
        {
            var user = await _repository.GetByToken(accessToken);
            if (user == null)
            {
                _logger.LogInformation($"User not found with access token: {accessToken}, a new user will be created");
            }
            return user;
        }

        private async Task CreateUserProfile(string token)
        {
            var userInformations = await _authenticationProvider.GetUserInformations(token);
            var userProfileToAdd = _mapper.Map<UserProfile>(userInformations);
            await _repository.AddUser(userProfileToAdd);
        }
    }  
}
