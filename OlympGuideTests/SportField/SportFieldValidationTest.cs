﻿using OlympGuide.Domain.Features.SportField;

namespace OlympGuideTests.SportField
{
    public class SportFieldValidationTest
    {

        [Fact]
        public void CheckSportFieldRequestDTO_ValidInput_ReturnsTrue()
        {
            // Arrange
            var sportFieldToCheck = new SportFieldType()
            {
                Name = "Football Field",
                Description = "Description",
                Longitude = -74.0060d,
                Latitude = 40.7128d
            };

            // Act
            var result = SportFieldValidation.CheckSportField(sportFieldToCheck);

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
                Longitude = -74.0060d,
                Latitude = 40.7128d
            };

            // Act
            var result = SportFieldValidation.CheckSportField(sportFieldToCheck);

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
                Longitude = -74.0060d,
                Latitude = 100.0d
            };

            // Act
            var result = SportFieldValidation.CheckSportField(sportFieldToCheck);

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
                Longitude = -200.0d,
                Latitude = 40.7128d
            };

            // Act
            var result = SportFieldValidation.CheckSportField(sportFieldToCheck);

            // Assert
            Assert.False(result);
        }

    }
}
