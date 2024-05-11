using Microsoft.EntityFrameworkCore;
using OlympGuide.Application.Features.TestData;
using OlympGuide.Infrastructre.Repositories;
using OlympGuide.Infrastructre;

namespace OlympGuideTests.TestData
{
    public class TestDataServiceTests
    {
        [Fact]
        public async Task CreateTestData_Successful_TableNotEmpty()
        {
            // Arrange
            var dbContext = this.CreateDbContext();
            var testDataRepository = new TestDataRepository(dbContext);
            var testDataService = new TestDataService(testDataRepository);
            
            // Act
            var amountCreated = await testDataService.CreateTestData();

            // Assert
            Assert.True(amountCreated > 0, "no test data were created");

            var reservationCount = dbContext.Reservations.Count();
            Assert.True(reservationCount > 0, "the reservation table is empty");

            var sportFieldCount = dbContext.SportFields.Count();
            Assert.True(sportFieldCount > 0, "the sport field table is empty");

            var sportFieldProposalCount = dbContext.SportFieldProposals.Count();
            Assert.True(sportFieldProposalCount > 0, "the sport field proposal table is empty");

            var userCount = dbContext.SportFieldProposals.Count();
            Assert.True(userCount > 0, "the user table is empty");
        }

        [Fact]
        public async Task DeleteTestData_Successful_TableEmpty()
        {
            // Arrange
            var dbContext = this.CreateDbContext();
            var testDataRepository = new TestDataRepository(dbContext);
            var testDataService = new TestDataService(testDataRepository);

            // Act
            await testDataService.CreateTestData();
            var amountDeleted = await testDataRepository.DeleteTestData();

            // Assert
            Assert.True(amountDeleted > 0, "No test data were deleted");

            var reservationCount = dbContext.Reservations.Count();
            Assert.True(reservationCount == 0, "the reservation table is not empty");

            var sportFieldCount = dbContext.SportFields.Count();
            Assert.True(sportFieldCount == 0, "the sport field table is not empty");

            var sportFieldProposalCount = dbContext.SportFieldProposals.Count();
            Assert.True(sportFieldProposalCount == 0, "the sport field proposal table is not empty");

            var userCount = dbContext.Users.Count();
            Assert.True(userCount == 0, "the user is not empty");
        }

        private OlympGuideDbContext CreateDbContext() {
            var options = new DbContextOptionsBuilder<OlympGuideDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDataServiceTests")
                .Options;
            var dbContext = new OlympGuideDbContext(options);

            return dbContext;
        }
    }
}