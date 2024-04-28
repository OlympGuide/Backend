
using OlympGuide.Domain.Features.SportFieldProposal;

namespace OlympGuide.Application.Features.SportFieldProposal
{
    public interface ISportFieldProposalService
    {
        public Task<List<SportFieldProposalType>> GetAllSportFieldProposals(SportFieldProposalStates? state);
        public Task<SportFieldProposalType> GetSportFieldProposalById(Guid sportFieldProposalId);
        public Task<SportFieldProposalType> AddSportFieldProposal(SportFieldProposalDto sportFieldProposalToAdd);
        public Task<SportFieldProposalType> ChangeStateById(Guid sportFieldProposalId, SportFieldProposalStates newState);
    }
}
