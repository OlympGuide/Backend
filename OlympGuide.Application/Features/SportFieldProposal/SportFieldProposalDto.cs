using OlympGuide.Domain.Features.SportField;

namespace OlympGuide.Application.Features.SportFieldProposal
{
    public record SportFieldProposalDto(string SportFieldName, string? SportFieldDescription, double SportFieldLongitude, double SportFieldLatitude, string? SportFieldAddress, SportFieldCategory Category);

}
