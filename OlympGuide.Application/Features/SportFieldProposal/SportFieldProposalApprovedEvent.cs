using MediatR;
using OlympGuide.Domain.Features.SportFieldProposal;

namespace OlympGuide.Application.Features.SportFieldProposal
{
    public class SportFieldProposalApprovedEvent : INotification
    {
        public SportFieldProposalApprovedEvent(SportFieldProposalType sportFieldProposal) {
            SportFieldProposal = sportFieldProposal;
        }
        public SportFieldProposalType SportFieldProposal { get; init; }
    }
}
