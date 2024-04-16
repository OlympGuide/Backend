using OlympGuide.Domain.Features.SportFieldProposal;

namespace OlympGuide.Application.Features.SportFieldProposal
{
    public record SportFieldProposalDetailsDto(Guid Id, DateTime Date, Guid UserId, string SportFieldName, string SportFieldDescription, float SportFieldLongitude, float SportFieldLatitude, string SportFieldAddress, SportFieldProposalStates State);
}
