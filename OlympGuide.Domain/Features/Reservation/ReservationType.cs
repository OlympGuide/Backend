using OlympGuide.Domain.Abstraction;
using OlympGuide.Domain.Features.User;

namespace OlympGuide.Domain.Features.Reservation
{
    public class ReservationType : Entity
    {
        public Guid SportFieldId { get; set; } = new();
        public UserProfile User { get; set; } = new();
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public ReservationStates State { get; set; }
    }
}
