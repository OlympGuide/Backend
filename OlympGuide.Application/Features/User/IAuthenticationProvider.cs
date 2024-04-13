using OlympGuide.Domain.Features.User;
using System.Text.Json.Nodes;

namespace OlympGuide.Application.Features.User
{
    public interface IAuthenticationProvider
    {        
        /// <summary>
        /// Retrieves and processes user information based on an access token.
        /// </summary>
        /// <param name="accessToken">The access token used to authenticate API calls.</param>
        /// <returns>A task that represents the asynchronous operation, resulting in user information.</returns>
        /// <exception cref="UserNotFoundException">Thrown if no user information is returned by the API.</exception>
        /// <exception cref="InvalidCastException">Thrown if the returned JSON cannot be parsed.</exception>
        Task<CreateUserInformations> GetUserInformations(string accessToken);
    }
}
