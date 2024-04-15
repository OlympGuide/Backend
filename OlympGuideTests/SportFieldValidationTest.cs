using OlympGuide.Application.Features.SportField;
using OlympGuide.Domain.Features.SportFieldProposal;

namespace OlympGuideTests
{
    public class SportFieldValidationTest
    {

        [Fact]
        public void CheckSportFieldRequestDTO_NullInput_ReturnsFalse()
        {
            // Act
            bool result = SportFieldValidation.CheckSportFieldProposal(null);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void CheckSportFieldRequestDTO_ValidInput_ReturnsTrue()
        {
            // Arrange
            var sportFieldToCheck = new SportFieldProposalType(){
                Date = DateTime.Now,
                UserId = Guid.Empty,
                SportFieldName = "Football Field",
                SportFieldDescription = "Description",
                SportFieldLongitude = -74.0060f,
                SportFieldLatitude = 40.7128f,
                State = SportFieldProposalStates.Open
            };

            // Act
            bool result = SportFieldValidation.CheckSportFieldProposal(sportFieldToCheck);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CheckSportFieldRequestDTO_EmptyName_ReturnsFalse()
        {
            // Arrange
            var sportFieldToCheck = new SportFieldProposalType() {
                Date = DateTime.Now,
                UserId = Guid.Empty,
                SportFieldName = "",
                SportFieldDescription = "Description",
                SportFieldLongitude = -74.0060f,
                SportFieldLatitude = 40.7128f,
                State = SportFieldProposalStates.Open
            };

            // Act
            bool result = SportFieldValidation.CheckSportFieldProposal(sportFieldToCheck);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void CheckSportFieldRequestDTO_InvalidLatitude_ReturnsFalse()
        {
            // Arrange
            var sportFieldToCheck = new SportFieldProposalType() {
                Date = DateTime.Now,
                UserId = Guid.Empty,
                SportFieldName = "Football Field",
                SportFieldDescription = "Description",
                SportFieldLongitude = -74.0060f,
                SportFieldLatitude = 100.0f,
                State = SportFieldProposalStates.Open
            };

            // Act
            bool result = SportFieldValidation.CheckSportFieldProposal(sportFieldToCheck);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void CheckSportFieldRequestDTO_InvalidLongitude_ReturnsFalse()
        {
            // Arrange
            var sportFieldToCheck = new SportFieldProposalType() {
                Date = DateTime.Now,
                UserId = Guid.Empty,
                SportFieldName = "Football Field",
                SportFieldDescription = "Description",
                SportFieldLongitude = -200.0f,
                SportFieldLatitude = 40.7128f,
                State = SportFieldProposalStates.Open
            };

            // Act
            bool result = SportFieldValidation.CheckSportFieldProposal(sportFieldToCheck);

            // Assert
            Assert.False(result);
        }

    }
}
