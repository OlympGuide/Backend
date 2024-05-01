using OlympGuide.Domain.Abstraction;
using OlympGuide.Domain.Features.User;

namespace OlympGuide.Domain.Features.SportFieldProposal
{
    public class SportFieldProposalType : Entity
    {
        public DateTime Date { get; set; }
        public required UserProfile User { get; set; }
        public string SportFieldName { get; set; } = string.Empty;
        public string? SportFieldDescription { get; set; }
        public double SportFieldLongitude { get; set; }
        public double SportFieldLatitude { get; set; }
        public string? SportFieldAddress {  get; set; }
        public SportFieldProposalStates State { get; set; } = SportFieldProposalStates.Open;
    }
}
