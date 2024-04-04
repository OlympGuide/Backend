
using OlympGuide.Domain.Features.SportField;

namespace OlympGuide.Application.Features.SportField
{
    public class SportFieldService(ISportFieldRepository repository) : ISportFieldService
    {
        private readonly ISportFieldRepository _repository = repository;

        public Task<SportFieldType> AddSportField(CreateSportFieldRequestDTO sportFieldToAdd)
        {
            SportFieldType newSportField = new SportFieldType()
            {
                Name = sportFieldToAdd.Name,
                Description = sportFieldToAdd.Description,
                Longitude = sportFieldToAdd.Longitude,
                Latitude = sportFieldToAdd.Latitude
            };

            return _repository.AddSportField(newSportField);
        }

        public Task<List<SportFieldType>> GetAllSportsField()
        {
            return _repository.GetAllSportsField();
        }

        public Task<SportFieldType> GetSportFieldByID(Guid sportFieldID)
        {
            return _repository.GetSportFieldByID(sportFieldID);
        }
    }
}
