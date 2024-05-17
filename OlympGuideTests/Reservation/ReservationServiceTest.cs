/*using Moq;
using OlympGuide.Application.Features.Reservation;
using OlympGuide.Application.Features.SportField;
using OlympGuide.Domain.Features.Reservation;
using OlympGuide.Domain.Features.User;

namespace OlympGuideTests.Reservation
{
    public class ReservationServiceTest
    {
        [Fact]
        public async Task GetAllReservations_AdminUser_ReturnsAllReservations()
        {
            // Arrange
            var repositoryMock = new Mock<IReservationRepository>();
            repositoryMock.Setup(repo => repo.GetAllReservations()).ReturnsAsync(new List<ReservationType>());
            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(service => service.GetCurrentUserFromUserContext()).ReturnsAsync(new UserProfile { Roles = new List<UserRole> { UserRole.Administrator } });
            var sportFieldServiceMock = new Mock<ISportFieldService>();
            var service = new ReservationService(repositoryMock.Object, userServiceMock.Object, sportFieldServiceMock.Object);

            // Act
            var result = await service.GetAllReservations();

            // Assert
            Assert.NotNull(result);
            repositoryMock.Verify(repo => repo.GetAllReservations(), Times.Once);
        }

        [Fact]
        public async Task GetAllReservations_DefaultUser_ReturnsReservationsByUser()
        {
            // Arrange
            var repositoryMock = new Mock<IReservationRepository>();
            repositoryMock.Setup(repo => repo.GetReservationsByUser(It.IsAny<UserProfile>())).ReturnsAsync(new List<ReservationType>());
            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(service => service.GetCurrentUserFromUserContext()).ReturnsAsync(new UserProfile { Roles = new List<UserRole> { UserRole.DefaultUser } });
            userServiceMock.Setup(service => service.GetUserProfile(It.IsAny<Guid>())).ReturnsAsync(new UserProfile());
            var sportFieldServiceMock = new Mock<ISportFieldService>();
            var service = new ReservationService(repositoryMock.Object, userServiceMock.Object, sportFieldServiceMock.Object);
            // Act
            var result = await service.GetAllReservations();

            // Assert
            Assert.NotNull(result);
            repositoryMock.Verify(repo => repo.GetReservationsByUser(It.IsAny<UserProfile>()), Times.Once);
        }

        [Fact]
        public async Task GetReservationById_ValidId_ReturnsReservation()
        {
            // Arrange
            var repositoryMock = new Mock<IReservationRepository>();
            var userServiceMock = new Mock<IUserService>();
            var user = new UserProfile { Roles = new List<UserRole> { UserRole.Administrator } };
            userServiceMock.Setup(service => service.GetCurrentUserFromUserContext()).ReturnsAsync(user);
            repositoryMock.Setup(repo => repo.GetReservationById(It.IsAny<Guid>())).ReturnsAsync(new ReservationType() { User = user});
            var sportFieldServiceMock = new Mock<ISportFieldService>();
            var service = new ReservationService(repositoryMock.Object, userServiceMock.Object, sportFieldServiceMock.Object); var validId = Guid.NewGuid();

            // Act
            var result = await service.GetReservationById(validId);

            // Assert
            Assert.NotNull(result);
            repositoryMock.Verify(repo => repo.GetReservationById(validId), Times.Once);
        }

        [Fact]
        public async Task GetReservationById_InvalidId_ThrowsNoReservationFoundException()
        {
            // Arrange
            var repositoryMock = new Mock<IReservationRepository>();
            repositoryMock.Setup(repo => repo.GetReservationById(It.IsAny<Guid>())).ThrowsAsync(new InvalidOperationException());
            var userServiceMock = new Mock<IUserService>();
            var service = new ReservationService(repositoryMock.Object, userServiceMock.Object);
            var invalidId = Guid.NewGuid(); // Hier verwenden wir eine gültige GUID, die jedoch keine Übereinstimmung im Repository hat

            // Act & Assert
            await Assert.ThrowsAsync<NoReservationFoundException>(() => service.GetReservationById(invalidId));
        }

        [Fact]
        public async Task GetReservationsBySportField_ValidId_ReturnsReservations()
        {
            // Arrange
            var repositoryMock = new Mock<IReservationRepository>();
            var userServiceMock = new Mock<IUserService>();
            repositoryMock.Setup(repo => repo.GetReservationsBySportField(It.IsAny<Guid>())).ReturnsAsync(new List<ReservationType>());
            var service = new ReservationService(repositoryMock.Object, userServiceMock.Object);
            var validId = Guid.NewGuid();

            // Act
            var result = await service.GetReservationsBySportField(validId);

            // Assert
            Assert.NotNull(result);
            repositoryMock.Verify(repo => repo.GetReservationsBySportField(validId), Times.Once);
        }

        [Fact]
        public async Task GetReservationsByUser_ValidId_ReturnsReservations()
        {
            // Arrange
            var repositoryMock = new Mock<IReservationRepository>();
            var userServiceMock = new Mock<IUserService>();
            repositoryMock.Setup(repo => repo.GetReservationsByUser(It.IsAny<UserProfile>())).ReturnsAsync(new List<ReservationType>());
            userServiceMock.Setup(service => service.GetUserProfile(It.IsAny<Guid>())).ReturnsAsync(new UserProfile());
            var service = new ReservationService(repositoryMock.Object, userServiceMock.Object);
            var validId = Guid.NewGuid();

            // Act
            var result = await service.GetReservationsByUser(validId);

            // Assert
            Assert.NotNull(result);
            repositoryMock.Verify(repo => repo.GetReservationsByUser(It.IsAny<UserProfile>()), Times.Once);
        }
    }
}
*/
