using OlympGuide.Domain.Features.SportField;

namespace OlympGuide.Application.Features.SportField
{
    public class SportFieldService(ISportFieldRepository repository) : ISportFieldService
    {
        private readonly ISportFieldRepository _repository = repository;

        public Task<SportFieldType> AddSportField(SportFieldType sportFieldToAdd)
        {
            if (SportFieldValidation.CheckSportField(sportFieldToAdd))
            {
                return _repository.AddSportField(sportFieldToAdd);
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
            
            try {
                var sportField = await _repository.GetSportFieldById(sportFieldId);
                return sportField;
            }
            catch(InvalidOperationException)
            {
                throw new NoSportFieldFoundException(sportFieldId);
            }
        }
    }
}
