using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using OlympGuide.Domain.Features.SportFieldProposal;
using OlympGuide.Domain.Features.User;
using OlympGuide.Infrastructre.Repositories;
using OlympGuide.Infrastructre;

namespace OlympGuideTests.SportFieldProposal
{
    public class SportFieldProposalRepositoryTest
    {
        [Fact]
        public async Task AddSportFieldProposal_UserProfileNotDuplicatedInUserTable()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<OlympGuideDbContext>()
                .UseInMemoryDatabase(databaseName: "SportFieldProposalServiceTests")
                .Options;
            var dbContext = new OlympGuideDbContext(options);
            var _proposalRepository = new SportFieldProposalRepository(dbContext);
            var _userRepository = new UserRepository(dbContext, new Mock<ILogger<UserRepository>>().Object);

            var user = new UserProfile();
            await _userRepository.AddUser(user);

            var newSportFieldProposal = new SportFieldProposalType()
            {
                Date = DateTime.UtcNow,
                User = user,
                SportFieldName = "Football Field",
                SportFieldDescription = "Description",
                SportFieldLatitude = 10.0f,
                SportFieldLongitude = 20.0f,
                SportFieldAddress = "123 Main St",
                State = SportFieldProposalStates.Open
            };

            // Act
            await _proposalRepository.AddSportFieldProposal(newSportFieldProposal);

            // Assert
            Assert.Equal(1, dbContext.Users.Count(u => u.Id == newSportFieldProposal.User.Id)); // Check if there is only one entry for the user ID
        }
    }
}
