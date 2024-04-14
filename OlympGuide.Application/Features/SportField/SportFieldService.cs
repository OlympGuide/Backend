using OlympGuide.Domain.Features.SportField;
using OlympGuide.Domain.Features.SportFieldProposal;

namespace OlympGuide.Application.Features.SportField
{
    public class SportFieldService(ISportFieldRepository repository) : ISportFieldService
    {
        private readonly ISportFieldRepository _repository = repository;

        public Task<SportFieldType> AddSportField(SportFieldProposalType sportFieldToAdd)
        {
            if (SportFieldValidation.CheckSportFieldProposal(sportFieldToAdd))
            {
                var newSportField = new SportFieldType()
                {
                    Name = sportFieldToAdd.SportFieldName,
                    Description = sportFieldToAdd.SportFieldDescription,
                    Longitude = sportFieldToAdd.SportFieldLongitude,
                    Latitude = sportFieldToAdd.SportFieldLatitude
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
