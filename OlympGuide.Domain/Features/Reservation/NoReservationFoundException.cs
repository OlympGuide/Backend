
namespace OlympGuide.Domain.Features.Reservation
{
    public class NoReservationFoundException(Guid id) : Exception(String.Format("Reservation with id: {0} was not found", id.ToString()));
}
