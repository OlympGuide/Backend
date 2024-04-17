using OlympGuide.Application.Features.SportFieldProposal;

namespace OlympGuide.Domain.Features.SportFieldProposal
{
    public interface ISportFieldProposalService
    {
        public Task<List<SportFieldProposalType>> GetAllSportFieldProposals();
        public Task<List<SportFieldProposalType>> GetAllOpenSportFieldProposals();
        public Task<SportFieldProposalType> GetSportFieldProposalById(Guid sportFieldProposalId);
        public Task<SportFieldProposalType> AddSportFieldProposal(SportFieldProposalDto sportFieldProposalToAdd);
        public Task<SportFieldProposalType> ChangeStateById(Guid sportFieldProposalId, SportFieldProposalStates newState);
    }
}
