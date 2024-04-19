using OlympGuide.Domain.Abstraction;
using OlympGuide.Domain.Features.User;

namespace OlympGuide.Domain.Features.SportFieldProposal
{
    public class SportFieldProposalType : Entity
    {
        public DateTime Date { get; set; }
        public UserProfile User { get; set; } = new();
        public string SportFieldName { get; set; } = string.Empty;
        public string SportFieldDescription { get; set; } = string.Empty;
        public double SportFieldLongitude { get; set; }
        public double SportFieldLatitude { get; set; }
        public string SportFieldAddress {  get; set; } = string.Empty;
        public SportFieldProposalStates State { get; set; } = SportFieldProposalStates.Open;
    }
}
