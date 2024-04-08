using OlympGuide.Domain.Features.SportField;

namespace OlympGuide.Application.Features.SportField
{
    public class SportFieldService(ISportFieldRepository repository) : ISportFieldService
    {
        private readonly ISportFieldRepository _repository = repository;

        public Task<SportFieldType> AddSportField(CreateSportFieldRequestDTO sportFieldToAdd)
        {
            if (sportFieldToAdd != null && SportFieldValidation.CheckSportFieldRequestDTO(sportFieldToAdd))
            {
                var newSportField = new SportFieldType()
                {
                    Name = sportFieldToAdd.Name,
                    Description = sportFieldToAdd.Description,
                    Longitude = sportFieldToAdd.Longitude,
                    Latitude = sportFieldToAdd.Latitude
                };

                return _repository.AddSportField(newSportField);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public Task<List<SportFieldType>> GetAllSportFields()
        {
            return _repository.GetAllSportFields();
        }

        public async Task<SportFieldType> GetSportFieldById(Guid sportFieldID)
        {
            if (sportFieldID == Guid.Empty)
            {
                throw new ArgumentException("Guid must no be null");
            }
            var sportField = await _repository.GetSportFieldById(sportFieldID);

            if (sportField == null)
            {
                throw new NoSportFieldFoundException(sportFieldID);
            }
            return sportField;
        }
    }
}
