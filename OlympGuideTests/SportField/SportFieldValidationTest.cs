using OlympGuide.Application.Features.SportField;
using OlympGuide.Domain.Features.SportField;
using OlympGuide.Domain.Features.SportFieldProposal;

namespace OlympGuideTests.SportField
{
    public class SportFieldValidationTest
    {

        [Fact]
        public void CheckSportFieldRequestDTO_NullInput_ReturnsFalse()
        {
            // Act
            bool result = SportFieldValidation.CheckSportField(null);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void CheckSportFieldRequestDTO_ValidInput_ReturnsTrue()
        {
            // Arrange
            var sportFieldToCheck = new SportFieldType()
            {
                Name = "Football Field",
                Description = "Description",
                Longitude = -74.0060f,
                Latitude = 40.7128f
            };

            // Act
            bool result = SportFieldValidation.CheckSportField(sportFieldToCheck);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CheckSportFieldRequestDTO_EmptyName_ReturnsFalse()
        {
            // Arrange
            var sportFieldToCheck = new SportFieldType()
            {
                Name = "",
                Description = "Description",
                Longitude = -74.0060f,
                Latitude = 40.7128f
            };

            // Act
            bool result = SportFieldValidation.CheckSportField(sportFieldToCheck);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void CheckSportFieldRequestDTO_InvalidLatitude_ReturnsFalse()
        {
            // Arrange
            var sportFieldToCheck = new SportFieldType()
            {
                Name = "Football Field",
                Description = "Description",
                Longitude = -74.0060f,
                Latitude = 100.0f
            };

            // Act
            bool result = SportFieldValidation.CheckSportField(sportFieldToCheck);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void CheckSportFieldRequestDTO_InvalidLongitude_ReturnsFalse()
        {
            // Arrange
            var sportFieldToCheck = new SportFieldType()
            {
                Name = "Football Field",
                Description = "Description",
                Longitude = -200.0f,
                Latitude = 40.7128f
            };

            // Act
            bool result = SportFieldValidation.CheckSportField(sportFieldToCheck);

            // Assert
            Assert.False(result);
        }

    }
}
