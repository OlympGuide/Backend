using OlympGuide.Domain.Features.SportFieldProposal;
using OlympGuide.Domain.Features.User;

namespace OlympGuide.Application.Features.SportFieldProposal
{
    public record SportFieldProposalDetailsDto(Guid Id, DateTime Date, UserProfile User, string SportFieldName, string? SportFieldDescription, double SportFieldLongitude, double SportFieldLatitude, string? SportFieldAddress, SportFieldProposalStates State);
}
