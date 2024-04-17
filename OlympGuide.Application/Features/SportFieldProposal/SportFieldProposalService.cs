using MediatR;
using OlympGuide.Application.Features.SportField;
using OlympGuide.Domain.Features.SportFieldProposal;

namespace OlympGuide.Application.Features.SportFieldProposal
{
    public class SportFieldProposalService(ISportFieldProposalRepository repository, IMediator mediator) : ISportFieldProposalService
    {
        private readonly ISportFieldProposalRepository _repository = repository;
        private readonly IMediator _mediator = mediator;

        public Task<List<SportFieldProposalType>> GetAllSportFieldProposals()
        {
            return _repository.GetAllSportFieldProposals();
        }

        public Task<List<SportFieldProposalType>> GetAllOpenSportFieldProposals()
        {
            return _repository.GetAllOpenSportFieldProposals();
        }

        public Task<SportFieldProposalType> AddSportFieldProposal(SportFieldProposalDto sportFieldProposalToAdd)
        {
            var newSportFieldProposal = new SportFieldProposalType()
            {
                Date = DateTime.UtcNow,
                UserId = Guid.Empty, //TODO: Replace with userID
                SportFieldName = sportFieldProposalToAdd.SportFieldName,
                SportFieldDescription = sportFieldProposalToAdd.SportFieldDescription,
                SportFieldLongitude = sportFieldProposalToAdd.SportFieldLongitude,
                SportFieldLatitude = sportFieldProposalToAdd.SportFieldLatitude,
                SportFieldAddress = sportFieldProposalToAdd.SportFieldAddress,
                State = SportFieldProposalStates.Open
            };

            return _repository.AddSportFieldProposal(newSportFieldProposal);
        }

        public async Task<SportFieldProposalType> GetSportFieldProposalById(Guid sportFieldProposalId)
        {
            if (sportFieldProposalId == Guid.Empty)
            {
                throw new ArgumentException("Guid must no be null");
            }

            try
            {
                var sportFieldProposal = await _repository.GetSportFieldProposalById(sportFieldProposalId);
                return sportFieldProposal;
            }
            catch (InvalidOperationException)
            {
                throw new NoSportFieldFoundException(sportFieldProposalId);
            }
        }

        public async Task<SportFieldProposalType> ChangeStateById(Guid sportFieldProposalId, SportFieldProposalStates newState)
        {
            if (sportFieldProposalId == Guid.Empty)
            {
                throw new ArgumentException("Guid must no be Empty");
            }
            try
            {
                var sportFieldProposal = await _repository.ChangeStateById(sportFieldProposalId, newState);
                if (newState == SportFieldProposalStates.Approved)
                {
                    var proposalEvent = new SportFieldProposalApprovedEvent(sportFieldProposal);
                    await _mediator.Publish(proposalEvent);
                }
                return sportFieldProposal;
            }
            catch(InvalidOperationException)
            {
                throw new NoSportFieldFoundException(sportFieldProposalId);
            }
        }
    }
}