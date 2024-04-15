using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using OlympGuide.Application.Features.User;
using OlympGuide.Domain.Features.User;

namespace OlympGuideTests.User
{
    public class UserServiceTests
    {
        private readonly Mock<ILogger<UserService>> _mockLogger;
        private readonly Mock<IUserRepository> _mockRepository;
        private readonly Mock<IAuthenticationProvider> _mockAuthProvider;
        private readonly Mock<IMapper> _mockMapper;
        private readonly UserService _userService;

        public UserServiceTests()
        {
            _mockLogger = new Mock<ILogger<UserService>>();
            _mockRepository = new Mock<IUserRepository>();
            _mockAuthProvider = new Mock<IAuthenticationProvider>();
            _mockMapper = new Mock<IMapper>();
            _userService = new UserService(_mockLogger.Object, _mockRepository.Object, _mockAuthProvider.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetUserProfile_ById_UserExists_ReturnsUserProfile()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var expectedUser = new UserProfile();
            _mockRepository.Setup(repo => repo.GetById(expectedUser.Id)).ReturnsAsync(expectedUser);

            // Act
            var result = await _userService.GetUserProfile(expectedUser.Id);

            // Assert
            Assert.Equal(expectedUser, result);
        }

        [Fact]
        public async Task GetUserProfileById_UserDoesNotExist_ThrowsUserNotFoundException()
        {
            // Arrange
            var userId = Guid.NewGuid();
            _mockRepository.Setup(repo => repo.GetById(userId)).ReturnsAsync((UserProfile)null);

            // Act & Assert
            await Assert.ThrowsAsync<UserNotFoundException>(() => _userService.GetUserProfile(userId));
        }

        [Fact]
        public async Task GetUserProfileByToken_UserExists_ReturnsUserProfile()
        {
            // Arrange
            var token = "valid-token";
            var expectedUser = new UserProfile();
            _mockRepository.Setup(repo => repo.GetByIdentifier(token)).ReturnsAsync(expectedUser);

            // Act
            var result = await _userService.GetUserProfile(token);

            // Assert
            Assert.Equal(expectedUser, result);
        }

        [Fact]
        public async Task GetUserProfileByToken_UserDoesNotExist_CreatesAndReturnsNewUser()
        {
            // Arrange
            var token = "valid-token";
            var newUser = new UserProfile();
            

            var userInformations = new CreateUserInformations(
            UserIdentifier: "asdf12ag451",
            Name: "John Doe",
            DisplayName: "JohnD",
            Email: "john.doe@example.com",
            Roles: new List<UserRole> { UserRole.DefaultUser, UserRole.Administrator });

            _mockRepository.SetupSequence(repo => repo.GetByIdentifier(userInformations.UserIdentifier))
                           .ReturnsAsync((UserProfile)null) // First call returns null, user not found
                           .ReturnsAsync(newUser); // Second call returns the newly created user


            _mockAuthProvider.Setup(auth => auth.GetUserInformations(token)).ReturnsAsync(userInformations);
            _mockMapper.Setup(mapper => mapper.Map<UserProfile>(It.IsAny<CreateUserInformations>())).Returns(newUser);
            _mockRepository.Setup(repo => repo.AddUser(newUser)).Returns(Task.FromResult(newUser));

            // Act
            var result = await _userService.GetUserProfile(token);

            // Assert
            Assert.Equal(newUser, result);
            _mockRepository.Verify(repo => repo.AddUser(It.IsAny<UserProfile>()), Times.Once);
        }

        [Fact]
        public async Task GetUserProfileByToken_CreationFails_ThrowsUserNotFoundException()
        {
            // Arrange
            var token = "valid-token";
            var newUser = new UserProfile();
   

            var userInformations = new CreateUserInformations(
            UserIdentifier: "asdf12ag451",
            Name: "John Doe",
            DisplayName: "JohnD",
            Email: "john.doe@example.com",
            Roles: new List<UserRole> { UserRole.DefaultUser, UserRole.Administrator });


            _mockRepository.Setup(repo => repo.GetByIdentifier(token)).ReturnsAsync((UserProfile)null);
            _mockAuthProvider.Setup(auth => auth.GetUserInformations(token)).ReturnsAsync(userInformations);
            
            _mockMapper.Setup(mapper => mapper.Map<UserProfile>(It.IsAny<CreateUserInformations>())).Returns(newUser);
            _mockRepository.Setup(repo => repo.AddUser(newUser)).Returns(Task.FromResult(newUser));
            _mockRepository.Setup(repo => repo.GetByIdentifier(userInformations.UserIdentifier)).ReturnsAsync((UserProfile)null); // Second call still returns null

            // Act & Assert
            await Assert.ThrowsAsync<UserNotFoundException>(() => _userService.GetUserProfile(token));
        }
    }

}
