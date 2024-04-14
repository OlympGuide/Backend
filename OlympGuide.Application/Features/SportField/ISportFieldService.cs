using OlympGuide.Domain.Features.SportField;
using OlympGuide.Domain.Features.SportFieldProposal;


namespace OlympGuide.Application.Features.SportField
{
    public interface ISportFieldService
    {
        public Task<List<SportFieldType>> GetAllSportFields();
        public Task<SportFieldType> GetSportFieldById(Guid sportFieldId);
        public Task<SportFieldType> AddSportField(SportFieldProposalType sportFieldToAdd);
    }
}
