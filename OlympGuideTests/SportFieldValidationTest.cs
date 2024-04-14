using OlympGuide.Application.Features.SportField;

namespace OlympGuideTests
{
    public class SportFieldValidationTest
    {

        [Fact]
        public void CheckSportFieldRequestDTO_NullInput_ReturnsFalse()
        {
            // Act
            bool result = SportFieldValidation.CheckSportFieldRequestDto(null);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void CheckSportFieldRequestDTO_ValidInput_ReturnsTrue()
        {
            // Arrange
            var sportFieldToCheck = new CreateSportFieldDto(
                "Football Field",
                "Description",
                -74.0060f,
                40.7128f
            );

            // Act
            bool result = SportFieldValidation.CheckSportFieldRequestDto(sportFieldToCheck);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CheckSportFieldRequestDTO_EmptyName_ReturnsFalse()
        {
            // Arrange
            var sportFieldToCheck = new CreateSportFieldDto(
                "",
                "Description",
                -74.0060f,
                40.7128f
            );

            // Act
            bool result = SportFieldValidation.CheckSportFieldRequestDto(sportFieldToCheck);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void CheckSportFieldRequestDTO_InvalidLatitude_ReturnsFalse()
        {
            // Arrange
            var sportFieldToCheck = new CreateSportFieldDto(
                "Football Field",
                "Description",
                -74.0060f,
                100.0f
            );

            // Act
            bool result = SportFieldValidation.CheckSportFieldRequestDto(sportFieldToCheck);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void CheckSportFieldRequestDTO_InvalidLongitude_ReturnsFalse()
        {
            // Arrange
            var sportFieldToCheck = new CreateSportFieldDto(
                "Football Field",
                "Description",
                -200.0f,
                40.7128f
            );

            // Act
            bool result = SportFieldValidation.CheckSportFieldRequestDto(sportFieldToCheck);

            // Assert
            Assert.False(result);
        }

    }
}
