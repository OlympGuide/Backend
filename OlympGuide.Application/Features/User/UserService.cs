﻿using AutoMapper;
using Microsoft.Extensions.Logging;
using OlympGuide.Domain.Features.User;

namespace OlympGuide.Application.Features.User
{
    public class UserService(ILogger<UserService> logger, IUserRepository repository, IAuthenticationProvider authenticationProvider, IMapper mapper) : IUserService
    {
        private readonly ILogger<UserService> _logger = logger;
        private readonly IUserRepository _repository = repository;
        private readonly IAuthenticationProvider _authenticationProvider = authenticationProvider;
        private readonly IMapper _mapper = mapper;

        public Task<Guid> GetUserId(string identifier)
        {
            return _repository.GetUserIdByAuthenticationProviderIdentifier(identifier);
        }

        /// <summary>
        /// Retrieves the user profile for a given user ID.
        /// </summary>
        /// <param name="id">The unique identifier for the user.</param>
        /// <returns>Returns a UserProfile object associated with the specified ID.</returns>
        /// <exception cref="UserNotFoundException">Thrown if no user is found with the provided ID.</exception>
        /// <remarks>
        /// This method accesses the user repository to fetch the user profile based on the user ID. If no user is found, it throws a UserNotFoundException with the user ID. This method is asynchronous and returns a Task.
        /// </remarks>
        public async Task<UserProfile> GetUserProfile(Guid id)
        {
            var user = await _repository.GetById(id);
            if (user == null)
                throw new UserNotFoundException(id);
            return user;
        }

        /// <summary>
        /// Retrieves the user profile based on the provided access token. If the user does not exist, it attempts to create a new user profile.
        /// </summary>
        /// <param name="accessToken">The access token used to identify the user.</param>
        /// <returns>The UserProfile object associated with the given access token. If the user cannot be found or created, an exception is thrown.</returns>
        /// <exception cref="UserNotFoundException">Thrown when a new user cannot be created after the initial retrieval fails. This exception is re-thrown after logging the error.</exception>
        /// <remarks>
        /// The method first attempts to retrieve the user by the access token. If the user is not found, it tries to create a new user profile. If creation is successful, it attempts to retrieve the user again. If the user still cannot be found, a UserNotFoundException is thrown. All exceptions are logged.
        /// </remarks>
        public async Task<UserProfile> GetUserProfile(string accessToken)
        {
            
            try
            {
                var userIdentifier = await _authenticationProvider.GetUserIdentifierFromToken(accessToken);
                var user = await _repository.GetByIdentifier(userIdentifier);
                return user;
            }
            catch(KeyNotFoundException ex)
            {
                _logger.LogInformation("JWT could not be parsed.");
                throw;
            }
            catch(UserNotFoundException ex)
            {
                _logger.LogInformation("User could not be found by token, new user is created.");
                await CreateUserProfile(accessToken);
                var userIdentifier = await _authenticationProvider.GetUserIdentifierFromToken(accessToken);
                var user = await _repository.GetByIdentifier(userIdentifier);
                return user ?? throw new UserNotFoundException("An unexpected error occours while creating a new user.");
            }
        }

        private async Task CreateUserProfile(string token)
        {
            var userInformations = await _authenticationProvider.GetUserInformations(token);
            var userProfileToAdd = _mapper.Map<UserProfile>(userInformations);
            var mapping = new AuthenticationUserMapping() { UserId= userProfileToAdd.Id, AuthenticationProviderId= userInformations.UserIdentifier};
            await _repository.AddUser(userProfileToAdd);
            await _repository.AddUserIdentifierMapping(mapping);
        }
    }  
}
