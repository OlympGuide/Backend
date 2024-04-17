using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using OlympGuide.Application.Features.User;
using OlympGuide.Domain.Features.User;
using OlympGuide.Infrastructre;
using OlympGuide.Infrastructre.Repositories;

namespace OlympGuideTests.User
{
    public class UserServiceTests
    {
        private readonly Mock<ILogger<UserService>> _mockLogger;
        private readonly IUserRepository _repository;
        private readonly Mock<IAuthenticationProvider> _mockAuthProvider;
        private readonly Mock<IMapper> _mockMapper;
        private readonly UserService _userService;
        private readonly Mock<IUserContext> _mockUserContext;
        public UserServiceTests()
        {
            var options = new DbContextOptionsBuilder<OlympGuideDbContext>()
            .UseInMemoryDatabase(databaseName: "UserServiceTests")
            .Options;
            
            _mockLogger = new Mock<ILogger<UserService>>();
            _repository = new UserRepository(new OlympGuideDbContext(options), new Mock<ILogger<UserRepository>>().Object);
            _mockAuthProvider = new Mock<IAuthenticationProvider>();
            _mockMapper = new Mock<IMapper>();
            _mockUserContext = new Mock<IUserContext>();
            _mockUserContext.Setup(c =>c.GetTokenFromCurrentUser()).Returns("eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJPbmxpbmUgSldUIEJ1aWxkZXIiLCJpYXQiOjE3MTMyNjMyMDgsImV4cCI6MTc0NDc5OTIwOCwiYXVkIjoid3d3LmV4YW1wbGUuY29tIiwic3ViIjoiYXNkZjEyYWc0NTEifQ.RIjdA138yIDKD2L_ll8kLi15cq1BcPw_aEtDMflsOI4");
            _userService = new UserService(_mockLogger.Object, _repository, _mockAuthProvider.Object, _mockUserContext.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetUserProfile_ById_UserExists_ReturnsUserProfile()
        {
            // Arrange
            var expectedUser = new UserProfile();
            await _repository.AddUser(expectedUser);

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
            

            // Act & Assert
            await Assert.ThrowsAsync<UserNotFoundException>(() => _userService.GetUserProfile(userId));
        }

        [Fact]
        public async Task GetUserProfileByToken_UserDoesNotExist_CreatesAndReturnsNewUser()
        {
            // Arrange
            var token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJPbmxpbmUgSldUIEJ1aWxkZXIiLCJpYXQiOjE3MTMyNjMyMDgsImV4cCI6MTc0NDc5OTIwOCwiYXVkIjoid3d3LmV4YW1wbGUuY29tIiwic3ViIjoiYXNkZjEyYWc0NTEifQ.RIjdA138yIDKD2L_ll8kLi15cq1BcPw_aEtDMflsOI4";
            var newUser = new UserProfile();
            

            var userInformations = new CreateUserInformations(
            UserIdentifier: "asdf12ag451",
            Name: "John Doe",
            DisplayName: "JohnD",
            Email: "john.doe@example.com",
            Roles: new List<UserRole> { UserRole.DefaultUser, UserRole.Administrator });


            _mockAuthProvider.Setup(auth => auth.GetUserInformations(token)).ReturnsAsync(userInformations);
            _mockAuthProvider.Setup(auth => auth.GetUserIdentifierFromToken(token)).ReturnsAsync(userInformations.UserIdentifier);
            _mockMapper.Setup(mapper => mapper.Map<UserProfile>(It.IsAny<CreateUserInformations>())).Returns(newUser);
           

            // Act
            var result = await _userService.GetUserProfile(token);
            var retrievedUser = await _userService.GetUserProfile(token); 
            // Assert
            Assert.Equal(newUser, result);
            Assert.Equal(retrievedUser, newUser);
        }

        [Fact]
        public async Task GetUserProfileByToken_CreationFails_ThrowsUserNotFoundException()
        {
            // Arrange
            var token = "valid-token";
            var newUser = new UserProfile();
            var mockRepository = new Mock<IUserRepository>();
            var serviceUnderTest = new UserService(_mockLogger.Object, mockRepository.Object, _mockAuthProvider.Object, _mockUserContext.Object, _mockMapper.Object);

            var userInformations = new CreateUserInformations(
            UserIdentifier: "asdf12ag451",
            Name: "John Doe",
            DisplayName: "JohnD",
            Email: "john.doe@example.com",
            Roles: new List<UserRole> { UserRole.DefaultUser, UserRole.Administrator });

            mockRepository.SetupSequence(repo => repo.GetByIdentifier(userInformations.UserIdentifier))
                           .ThrowsAsync(new UserNotFoundException(token))
                           .ThrowsAsync(new UserNotFoundException(token));

            _mockAuthProvider.Setup(p => p.GetUserIdentifierFromToken(token)).ThrowsAsync(new UserNotFoundException(token));
            _mockAuthProvider.Setup(auth => auth.GetUserInformations(token)).ReturnsAsync(userInformations);

            _mockMapper.Setup(mapper => mapper.Map<UserProfile>(It.IsAny<CreateUserInformations>())).Returns(newUser);
            mockRepository.Setup(repo => repo.AddUser(newUser)).Returns(Task.FromResult(newUser));
   
            // Act & Assert
            await Assert.ThrowsAsync<UserNotFoundException>(() => serviceUnderTest.GetUserProfile(token));
        }
    }

}
