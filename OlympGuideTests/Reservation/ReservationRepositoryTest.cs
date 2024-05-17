

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using OlympGuide.Domain.Features.User;
using OlympGuide.Infrastructre.Repositories;
using OlympGuide.Infrastructre;
using OlympGuide.Domain.Features.Reservation;
using OlympGuide.Domain.Features.SportField;

namespace OlympGuideTests.Reservation
{
    public class ReservationRepositoryTest
    {
        [Fact]
        public async Task AddSportFieldProposal_UserProfileNotDuplicatedInUserTable()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<OlympGuideDbContext>()
                .UseInMemoryDatabase(databaseName: "ReservationServiceTests")
                .Options;
            var dbContext = new OlympGuideDbContext(options);
            var reservationRepository = new ReservationRepository(dbContext);
            var userRepository = new UserRepository(dbContext, new Mock<ILogger<UserRepository>>().Object);

            var user = new UserProfile();
            await userRepository.AddUser(user);

            var sportField = new SportFieldType();


            var newReservation = new ReservationType()
            {
                User = user,
                SportField = sportField,
                Start = DateTime.Now,
                End = DateTime.Now,
                State = ReservationStates.Open
            };

            // Act
            await reservationRepository.AddReservation(newReservation);

            var result = await reservationRepository.GetReservationsBySportField(sportField.Id);

            // Assert
            Assert.Equal(user, result[0].User); // Check if there is only one entry for the user ID
        }
    }
}
