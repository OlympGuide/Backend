using MediatR;

namespace OlympGuide.Domain.Features.SportFieldProposal
{
    public class SportFieldProposalApprovedEvent : INotification
    {
        public SportFieldProposalApprovedEvent(SportFieldProposalType sportFieldProposal) {
            SportFieldProposal = sportFieldProposal;
        }
        public SportFieldProposalType SportFieldProposal { get; init; }
    }
}
