using OlympGuide.Application.Features.User;
using OlympGuide.Domain.Features.SportFieldProposal;

namespace OlympGuide.Application.Features.SportFieldProposal
{
    public record SportFieldProposalDetailsDto(Guid Id, DateTime Date, UserProfileDto User, string SportFieldName, string? SportFieldDescription, double SportFieldLongitude, double SportFieldLatitude, string? SportFieldAddress, SportFieldProposalStates State);
}
