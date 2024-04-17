namespace OlympGuide.Domain.Features.SportFieldProposal
{
    public interface ISportFieldProposalRepository
    {
        public Task<List<SportFieldProposalType>> GetAllSportFieldProposals();
        public Task<List<SportFieldProposalType>> GetAllOpenSportFieldProposals();
        public Task<SportFieldProposalType> GetSportFieldProposalById(Guid sportFieldProposalId);
        public Task<SportFieldProposalType> AddSportFieldProposal(SportFieldProposalType sportFieldProposalToAdd);
        public Task<SportFieldProposalType> ChangeStateById(Guid sportFieldProposalId, SportFieldProposalStates newState);

    }
}
