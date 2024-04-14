using OlympGuide.Domain.Abstraction;

namespace OlympGuide.Domain.Features.SportFieldProposal
{
    public class SportFieldProposalType : Entity
    {
        public DateTime Date { get; set; }
        public Guid UserId { get; set; }
        public string SportFieldName { get; set; } = string.Empty;
        public string SportFieldDescription { get; set; } = string.Empty;
        public float SportFieldLongitude { get; set; }
        public float SportFieldLatitude { get; set; }
        public SportFieldProposalStates State { get; set; } = SportFieldProposalStates.Open;
    }
}
