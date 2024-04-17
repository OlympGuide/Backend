using Microsoft.AspNetCore.Http;
using Moq;
using OlympGuide.Features.User;

namespace OlympGuideTests.User
{
    public class UserContextTests
    {
        private readonly Mock<IHttpContextAccessor> _mockHttpContextAccessor;
        private readonly UserContext _userContext;

        public UserContextTests()
        {
            _mockHttpContextAccessor = new Mock<IHttpContextAccessor>();
            _userContext = new UserContext(_mockHttpContextAccessor.Object);
        }

        [Fact]
        public void GetTokenFromCurrentUser_NoHttpContext_ReturnsNull()
        {
            // Arrange
            _mockHttpContextAccessor.Setup(x => x.HttpContext).Returns((HttpContext)null);

            // Act
            var result = _userContext.GetTokenFromCurrentUser();

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void GetTokenFromCurrentUser_NoAuthorizationHeader_ReturnsNull()
        {
            // Arrange
            var context = new DefaultHttpContext();
            _mockHttpContextAccessor.Setup(x => x.HttpContext).Returns(context);

            // Act
            var result = _userContext.GetTokenFromCurrentUser();

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void GetTokenFromCurrentUser_ValidAuthorizationHeader_ReturnsToken()
        {
            // Arrange
            var context = new DefaultHttpContext();
            context.Request.Headers["Authorization"] = "Bearer validToken123";
            _mockHttpContextAccessor.Setup(x => x.HttpContext).Returns(context);

            // Act
            var result = _userContext.GetTokenFromCurrentUser();

            // Assert
            Assert.Equal("validToken123", result);
        }
    }
}
