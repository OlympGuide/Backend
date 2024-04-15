using OlympGuide.Application.Features.User;
using OlympGuide.Domain.Features.User;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace OlympGuide.Authentication
{
    public class Auth0AuthenticationProvider(IConfiguration configuration ,ILogger<Auth0AuthenticationProvider> logger) : IAuthenticationProvider
    {
        private readonly IConfiguration _configuration = configuration;
        private readonly HttpClient _httpClient = new();
        private readonly ILogger<Auth0AuthenticationProvider> _logger = logger;

        /// <summary>
        /// Retrieves and processes user information based on an access token.
        /// </summary>
        /// <param name="accessToken">The access token used to authenticate API calls.</param>
        /// <returns>A task that represents the asynchronous operation, resulting in user information.</returns>
        /// <exception cref="UserNotFoundException">Thrown if no user information is returned by the API.</exception>
        /// <exception cref="InvalidCastException">Thrown if the returned JSON cannot be parsed.</exception>
        public async Task<CreateUserInformations> GetUserInformations(string accessToken)
        {
            var jsonString = await MakeAPICallForUserInformations(accessToken);

            if (string.IsNullOrEmpty(jsonString))
            {
                throw new UserNotFoundException(accessToken);
            }

            var result = JsonSerializer.Deserialize<JsonObject>(jsonString);
            if (result == null)
            {
                throw new InvalidCastException($"Json could not be parsed: {jsonString}");
            }

            var userRoles = GetUserRoles(accessToken);
            return MapUserInformations(result, userRoles);
        }

        /// <summary>
        /// Retrieves user roles based on claims contained in the JWT extracted from the provided access token.
        /// </summary>
        /// <param name="accessToken">The JWT access token containing role claims.</param>
        /// <returns>A list of user roles extracted from the token.</returns>
        private List<UserRole> GetUserRoles(string accessToken)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(accessToken);

            var permissions = jwtToken.Claims.Where(claim => claim.Type == "permissions").ToList();
            var roles = new List<UserRole>();

            foreach(var permission in permissions)
            {
                UserRole role;
                if (Auth0ApiKeys.PermissionMap.TryGetValue(permission.Value, out role))
                {
                    roles.Add(role);
                }
            }
            return roles;
        }

        /// <summary>
        /// Makes an API call to a specified user information endpoint using an access token.
        /// </summary>
        /// <param name="accessToken">The access token used to authenticate with the API.</param>
        /// <returns>A task that represents the asynchronous operation, resulting in the JSON string returned by the API.</returns>
        private async Task<string> MakeAPICallForUserInformations(string accessToken)
        {
            var domain = _configuration["Auth0:Domain"]!;
            string url = $"https://{domain}/userinfo";

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// Maps JSON object containing user information to a CreateUserInformations object while validating required fields.
        /// </summary>
        /// <param name="informations">The JSON object containing user details.</param>
        /// <param name="userRoles">The list of user roles to be included in the user information.</param>
        /// <returns>A CreateUserInformations object populated with data from the JSON object and roles.</returns>
        /// <exception cref="InvalidDataException">Thrown if required user information is missing.</exception>
        private CreateUserInformations MapUserInformations(JsonObject informations,List<UserRole> userRoles )
        {
            if (!CheckInformations(informations))
                throw new InvalidDataException("User informations does not contains all requiered informations");

            return new CreateUserInformations(
                    (string)informations[Auth0ApiKeys.UserIdentifierKey]!,
                    (string)informations[Auth0ApiKeys.NameKey]!,
                    (string)informations[Auth0ApiKeys.DisplayNameKey]!,
                    (string)informations[Auth0ApiKeys.EmailKey]!,
                    userRoles
                ) ;
        }

        /// <summary>
        /// Checks if the JSON object contains all required user information fields.
        /// </summary>
        /// <param name="informations">The JSON object to check.</param>
        /// <returns>True if all required fields are present; otherwise, false.</returns>
        private bool CheckInformations(JsonObject informations)
        {
           foreach(var key in Auth0ApiKeys.UserInformationKeys)
            {
                if(!informations.ContainsKey(key))
                {
                    _logger.LogError($"Obtained user informations does not container required property: {key}");
                    return false;
                }
            }
            return true;
        }

        public Task<string> GetUserIdentifierFromToken(string accessToken)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(accessToken);

            var identifier = jwtToken.Claims.Where(claim => claim.Type == "sub").Single();
            if (identifier == null)
                throw new KeyNotFoundException("JWT does not contains required indentifier");
            return Task.FromResult(identifier.Value);
        }
    }
}
