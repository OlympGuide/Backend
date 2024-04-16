using MediatR;
using OlympGuide.Domain.Features.SportFieldProposal;

namespace OlympGuide.Application.Features.SportFieldProposal
{
    public class SportFieldProposalAcceptedEvent : INotification
    {
        public SportFieldProposalAcceptedEvent(SportFieldProposalType sportFieldProposal) {
            SportFieldProposal = sportFieldProposal;
        }
        public SportFieldProposalType SportFieldProposal { get; init; }
    }
}
