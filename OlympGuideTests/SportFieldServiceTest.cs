﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using OlympGuide.Domain.Features.SportField;
using Xunit;

namespace OlympGuide.Application.Features.SportField.Tests
{
    public class SportFieldServiceTests
    {
        [Fact]
        public async Task AddSportField_InvalidInput_ThrowsArgumentException()
        {
            // Arrange
            var repositoryMock = new Mock<ISportFieldRepository>();
            var service = new SportFieldService(repositoryMock.Object);
            CreateSportFieldRequestDTO invalidRequest = null;

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => service.AddSportField(invalidRequest));

        }

        [Fact]
        public async Task AddSportField_ValidInput_CallsRepositoryAddSportField()
        {
            // Arrange
            var repositoryMock = new Mock<ISportFieldRepository>();
            var service = new SportFieldService(repositoryMock.Object);
            CreateSportFieldRequestDTO validRequest = new CreateSportFieldRequestDTO("Field", "Description", 10.0f, 20.0f);

            // Act
            await service.AddSportField(validRequest);

            // Assert
            repositoryMock.Verify(repo => repo.AddSportField(It.IsAny<Domain.Features.SportField.SportField>()), Times.Once);
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
            await Assert.ThrowsAsync<ArgumentException>(() => service.GetSportFieldByID(Guid.Empty));
        }

        [Fact]
        public async Task GetSportFieldByID_NoSportFieldFound_ThrowsNoSportFieldFoundException()
        {
            // Arrange
            var repositoryMock = new Mock<ISportFieldRepository>();
            repositoryMock.Setup(repo => repo.GetSportFieldByID(It.IsAny<Guid>())).ReturnsAsync((Domain.Features.SportField.SportField)null);
            var service = new SportFieldService(repositoryMock.Object);
            Guid validId = Guid.NewGuid();

            // Act & Assert
            await Assert.ThrowsAsync<NoSportFieldFoundException>(() => service.GetSportFieldByID(validId));
        }

        [Fact]
        public async Task GetSportFieldByID_ValidID_CallsRepositoryGetSportFieldByID()
        {
            // Arrange
            var repositoryMock = new Mock<ISportFieldRepository>();
            repositoryMock.Setup(repo => repo.GetSportFieldByID(It.IsAny<Guid>())).ReturnsAsync(new Domain.Features.SportField.SportField());
            var service = new SportFieldService(repositoryMock.Object);
            Guid validId = Guid.NewGuid();

            // Act
            await service.GetSportFieldByID(validId);

            // Assert
            repositoryMock.Verify(repo => repo.GetSportFieldByID(validId), Times.Once);
        }
    }
}