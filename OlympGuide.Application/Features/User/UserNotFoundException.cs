namespace OlympGuide.Application.Features.User
{
    public class UserNotFoundException: Exception
    {
        public UserNotFoundException(Guid id) : base($"User with id: {id} not found") { }
        public UserNotFoundException(string token) : base($"User with token: {token} not found") { }
    }
}
