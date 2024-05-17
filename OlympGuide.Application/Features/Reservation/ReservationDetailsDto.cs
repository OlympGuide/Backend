using OlympGuide.Application.Features.SportField;
using OlympGuide.Application.Features.User;
using OlympGuide.Domain.Features.Reservation;

namespace OlympGuide.Application.Features.Reservation
{
    public record ReservationDetailsDto(Guid Id, SportFieldDto SportField, UserProfileDto User, DateTime Start, DateTime End, ReservationStates State);

}
