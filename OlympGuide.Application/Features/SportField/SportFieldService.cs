using OlympGuide.Domain.Features.SportField;

namespace OlympGuide.Application.Features.SportField
{
    public class SportFieldService(ISportFieldRepository repository) : ISportFieldService
    {
        private readonly ISportFieldRepository _repository = repository;

        public Task<SportFieldType> AddSportField(CreateSportFieldRequestDto sportFieldToAdd)
        {
            if (SportFieldValidation.CheckSportFieldRequestDTO(sportFieldToAdd))
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
                throw new ArgumentException();
        }

        public Task<List<SportFieldType>> GetAllSportFields()
        {
            return _repository.GetAllSportFields();
        }

        public async Task<SportFieldType> GetSportFieldById(Guid sportFieldId)
        {
            if (sportFieldId == Guid.Empty)
            {
                throw new ArgumentException("Guid must no be null");
            }
            var sportField = await _repository.GetSportFieldById(sportFieldId);

            if (sportField == null)
            {
                throw new NoSportFieldFoundException(sportFieldId);
            }
            return sportField;
        }
    }
}
