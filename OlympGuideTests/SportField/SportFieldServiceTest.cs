using Moq;
using OlympGuide.Application.Features.SportField;
using OlympGuide.Domain.Features.SportField;

namespace OlympGuideTests.SportField
{
    public class SportFieldServiceTests
    {
        [Fact]
        public async Task AddSportField_InvalidInput_ThrowsArgumentException()
        {
            // Arrange
            var repositoryMock = new Mock<ISportFieldRepository>();
            var service = new SportFieldService(repositoryMock.Object);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => service.AddSportField(null!));

        }

        [Fact]
        public async Task AddSportField_ValidInput_CallsRepositoryAddSportField()
        {
            // Arrange
            var repositoryMock = new Mock<ISportFieldRepository>();
            var service = new SportFieldService(repositoryMock.Object);
            var validRequest = new SportFieldType()
            {
                Name = "Football Field",
                Description = "Description",
                Longitude = 10.0f,
                Latitude = 20.0f
            };

            // Act
            await service.AddSportField(validRequest);

            // Assert
            repositoryMock.Verify(repo => repo.AddSportField(It.IsAny<SportFieldType>()), Times.Once);
        }

        [Fact]
        public async Task GetAllSportFields_CallsRepositoryGetAllSportFields()
        {
            // Arrange
            var repositoryMock = new Mock<ISportFieldRepository>();
            var service = new SportFieldService(repositoryMock.Object);

            // Act
            await service.GetAllSportFields();

            // Assert
            repositoryMock.Verify(repo => repo.GetAllSportFields(), Times.Once);
        }

        [Fact]
        public async Task GetSportFieldByID_EmptyID_ThrowsArgumentException()
        {
            // Arrange
            var repositoryMock = new Mock<ISportFieldRepository>();
            var service = new SportFieldService(repositoryMock.Object);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => service.GetSportFieldById(Guid.Empty));
        }

        [Fact]
        public async Task GetSportFieldByID_NoSportFieldFound_ThrowsNoSportFieldFoundException()
        {
            // Arrange
            var repositoryMock = new Mock<ISportFieldRepository>();
            repositoryMock.Setup(repo => repo.GetSportFieldById(It.IsAny<Guid>())).ThrowsAsync(new InvalidOperationException());
            var service = new SportFieldService(repositoryMock.Object);
            var validId = Guid.NewGuid();

            // Act & Assert
            await Assert.ThrowsAsync<NoSportFieldFoundException>(() => service.GetSportFieldById(validId));
        }

        [Fact]
        public async Task GetSportFieldByID_ValidID_CallsRepositoryGetSportFieldByID()
        {
            // Arrange
            var repositoryMock = new Mock<ISportFieldRepository>();
            repositoryMock.Setup(repo => repo.GetSportFieldById(It.IsAny<Guid>())).ReturnsAsync(new SportFieldType());
            var service = new SportFieldService(repositoryMock.Object);
            var validId = Guid.NewGuid();

            // Act
            await service.GetSportFieldById(validId);

            // Assert
            repositoryMock.Verify(repo => repo.GetSportFieldById(validId), Times.Once);
        }
    }
}