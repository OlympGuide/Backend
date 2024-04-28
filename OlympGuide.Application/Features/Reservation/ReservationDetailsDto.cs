using OlympGuide.Domain.Features.Reservation;
using OlympGuide.Domain.Features.User;

namespace OlympGuide.Application.Features.Reservation
{
    public record ReservationDetailsDto(Guid Id, Guid SportFieldId, UserProfile User, DateTime Start, DateTime End, ReservationStates State);

}
