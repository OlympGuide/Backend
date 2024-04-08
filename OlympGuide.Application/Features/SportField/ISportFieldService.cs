﻿using OlympGuide.Domain.Features.SportField;


namespace OlympGuide.Application.Features.SportField
{
    public interface ISportFieldService
    {
        public Task<List<SportFieldType>> GetAllSportFields();
        public Task<SportFieldType> GetSportFieldById(Guid sportFieldID);
        public Task<SportFieldType> AddSportField(CreateSportFieldRequestDTO sportFieldToAdd);
    }
}
