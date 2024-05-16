using OlympGuide.Domain.Abstraction;
using OlympGuide.Domain.Features.SportField;
using OlympGuide.Domain.Features.User;

namespace OlympGuide.Domain.Features.Reservation
{
    public class ReservationType : Entity
    {
        public virtual required SportFieldType SportField { get; set; }
        public virtual required UserProfile User { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public ReservationStates State { get; set; }
    }
}
