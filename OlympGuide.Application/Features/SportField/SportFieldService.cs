using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OlympGuide.Application.Features.SportField;

namespace OlympGuide.Domain.Features.SportField
{
    public class SportFieldService(ISportFieldRepository repository) : ISportFieldService
    {
        private readonly ISportFieldRepository _repository = repository;

        public Task<SportField> AddSportField(CreateSportFieldRequestDTO sportFieldToAdd)
        {
            SportField newSportField = new SportField();
            newSportField.Name = sportFieldToAdd.Name;
            newSportField.Description = sportFieldToAdd.Description;
            newSportField.Latitude = sportFieldToAdd.Latitude;
            newSportField.Longitude = sportFieldToAdd.Longitude;

            return _repository.AddSportField(newSportField);
        }

        public Task<List<SportField>> GetAllSportsField()
        {
            return _repository.GetAllSportsField();
        }

        public Task<SportField> GetSportFieldByID(Guid sportFieldID)
        {
            return _repository.GetSportFieldByID(sportFieldID);
        }
    }
}
