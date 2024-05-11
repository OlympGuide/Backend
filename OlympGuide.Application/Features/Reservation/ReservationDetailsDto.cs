using OlympGuide.Application.Features.User;
using OlympGuide.Domain.Features.Reservation;

namespace OlympGuide.Application.Features.Reservation
{
    public record ReservationDetailsDto(Guid Id, Guid SportFieldId, UserProfileDto User, DateTime Start, DateTime End, ReservationStates State);

}
