using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;
using OlympGuide.Application.Features.SportField;

namespace OlympGuideTests
{
    public class SportFieldValidationTest
    {

        [Fact]
        public void CheckSportFieldRequestDTO_NullInput_ReturnsFalse()
        {
            // Arrange
            CreateSportFieldRequestDTO sportFieldToCheck = null;

            // Act
            bool result = SportFieldValidation.CheckSportFieldRequestDTO(sportFieldToCheck);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void CheckSportFieldRequestDTO_ValidInput_ReturnsTrue()
        {
            // Arrange
            CreateSportFieldRequestDTO sportFieldToCheck = new CreateSportFieldRequestDTO(
                "Football Field",
                "Description",
                -74.0060f,
                40.7128f
            );

            // Act
            bool result = SportFieldValidation.CheckSportFieldRequestDTO(sportFieldToCheck);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CheckSportFieldRequestDTO_NullName_ReturnsFalse()
        {
            // Arrange
            CreateSportFieldRequestDTO sportFieldToCheck = new CreateSportFieldRequestDTO(
                null,
                "Description",
                -74.0060f,
                40.7128f
            );

            // Act
            bool result = SportFieldValidation.CheckSportFieldRequestDTO(sportFieldToCheck);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void CheckSportFieldRequestDTO_EmptyName_ReturnsFalse()
        {
            // Arrange
            CreateSportFieldRequestDTO sportFieldToCheck = new CreateSportFieldRequestDTO(
                "",
                "Description",
                -74.0060f,
                40.7128f
            );

            // Act
            bool result = SportFieldValidation.CheckSportFieldRequestDTO(sportFieldToCheck);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void CheckSportFieldRequestDTO_InvalidLatitude_ReturnsFalse()
        {
            // Arrange
            CreateSportFieldRequestDTO sportFieldToCheck = new CreateSportFieldRequestDTO(
                "Football Field",
                "Description",
                -74.0060f,
                100.0f
            );

            // Act
            bool result = SportFieldValidation.CheckSportFieldRequestDTO(sportFieldToCheck);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void CheckSportFieldRequestDTO_InvalidLongitude_ReturnsFalse()
        {
            // Arrange
            CreateSportFieldRequestDTO sportFieldToCheck = new CreateSportFieldRequestDTO(
                "Football Field",
                "Description",
                -200.0f,
                40.7128f
            );

            // Act
            bool result = SportFieldValidation.CheckSportFieldRequestDTO(sportFieldToCheck);

            // Assert
            Assert.False(result);
        }

    }
}
