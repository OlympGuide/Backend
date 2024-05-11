using Moq;
using OlympGuide.Application.Features.SportFieldProposal;
using OlympGuide.Domain.Features.SportFieldProposal;
using MediatR;
using OlympGuide.Domain.Features.SportField;
using OlympGuide.Domain.Features.User;

namespace OlympGuideTests.SportFieldProposal
{
    public class SportFieldProposalServiceTests
    {

        [Fact]
        public async Task AddSportFieldProposal_ValidInput_CallsRepositoryAddSportFieldProposal()
        {
            // Arrange
            var repositoryMock = new Mock<ISportFieldProposalRepository>();
            var mediatorMock = new Mock<IMediator>();
            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(service => service.GetCurrentUserIdFromUserContext()).ReturnsAsync(Guid.Empty);
            var service = new SportFieldProposalService(repositoryMock.Object, mediatorMock.Object, userServiceMock.Object);
            var validRequest = new SportFieldProposalDto(
                "Football Field",
                "Description",
                10.0f,
                20.0f,
                "123 Main St",
                SportFieldCategory.Soccer
            );

            // Act
            await service.AddSportFieldProposal(validRequest);

            // Assert
            repositoryMock.Verify(repo => repo.AddSportFieldProposal(It.IsAny<SportFieldProposalType>()), Times.Once);
        }

        [Fact]
        public async Task GetSportFieldProposalById_EmptyID_ThrowsArgumentException()
        {
            // Arrange
            var repositoryMock = new Mock<ISportFieldProposalRepository>();
            var mediatorMock = new Mock<IMediator>();
            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(service => service.GetCurrentUserIdFromUserContext()).ReturnsAsync(Guid.Empty);
            var service = new SportFieldProposalService(repositoryMock.Object, mediatorMock.Object, userServiceMock.Object);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => service.GetSportFieldProposalById(Guid.Empty));
        }

        [Fact]
        public async Task GetSportFieldProposalById_NoSportFieldFound_ThrowsNoSportFieldFoundException()
        {
            // Arrange
            var repositoryMock = new Mock<ISportFieldProposalRepository>();
            repositoryMock.Setup(repo => repo.GetSportFieldProposalById(It.IsAny<Guid>())).ThrowsAsync(new InvalidOperationException());
            var mediatorMock = new Mock<IMediator>();
            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(service => service.GetCurrentUserIdFromUserContext()).ReturnsAsync(Guid.Empty);
            var service = new SportFieldProposalService(repositoryMock.Object, mediatorMock.Object, userServiceMock.Object);
            var validId = Guid.NewGuid();

            // Act & Assert
            await Assert.ThrowsAsync<NoSportFieldFoundException>(() => service.GetSportFieldProposalById(validId));
        }

        [Fact]
        public async Task ChangeStateById_EmptyID_ThrowsArgumentException()
        {
            // Arrange
            var repositoryMock = new Mock<ISportFieldProposalRepository>();
            var mediatorMock = new Mock<IMediator>();
            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(service => service.GetCurrentUserIdFromUserContext()).ReturnsAsync(Guid.Empty);
            var service = new SportFieldProposalService(repositoryMock.Object, mediatorMock.Object, userServiceMock.Object);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => service.ChangeStateById(Guid.Empty, SportFieldProposalStates.Open));
        }

        [Fact]
        public async Task ChangeStateById_NoSportFieldFound_ThrowsNoSportFieldFoundException()
        {
            // Arrange
            var repositoryMock = new Mock<ISportFieldProposalRepository>();
            repositoryMock.Setup(repo => repo.ChangeStateById(It.IsAny<Guid>(), It.IsAny<SportFieldProposalStates>())).ThrowsAsync(new InvalidOperationException());
            var mediatorMock = new Mock<IMediator>();
            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(service => service.GetCurrentUserIdFromUserContext()).ReturnsAsync(Guid.Empty);
            var service = new SportFieldProposalService(repositoryMock.Object, mediatorMock.Object, userServiceMock.Object);
            var validId = Guid.NewGuid();

            // Act & Assert
            await Assert.ThrowsAsync<NoSportFieldFoundException>(() => service.ChangeStateById(validId, SportFieldProposalStates.Open));
        }

        [Fact]
        public async Task ChangeStateById_ValidID_CallsRepositoryChangeStateById()
        {
            // Arrange
            var repositoryMock = new Mock<ISportFieldProposalRepository>();
            var sportFieldProposal = new SportFieldProposalType()
            {
                User = new UserProfile()
            };
            repositoryMock.Setup(repo => repo.ChangeStateById(It.IsAny<Guid>(), It.IsAny<SportFieldProposalStates>())).ReturnsAsync(sportFieldProposal);
            var mediatorMock = new Mock<IMediator>();
            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(service => service.GetCurrentUserIdFromUserContext()).ReturnsAsync(Guid.Empty);
            var service = new SportFieldProposalService(repositoryMock.Object, mediatorMock.Object, userServiceMock.Object);
            var validId = Guid.NewGuid();

            // Act
            await service.ChangeStateById(validId, SportFieldProposalStates.Open);

            // Assert
            repositoryMock.Verify(repo => repo.ChangeStateById(validId, SportFieldProposalStates.Open), Times.Once);
        }
    }
}