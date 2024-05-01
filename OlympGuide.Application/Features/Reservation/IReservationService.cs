using OlympGuide.Domain.Features.Reservation;

namespace OlympGuide.Application.Features.Reservation
{
    public interface IReservationService
    {
        public Task<List<ReservationType>> GetAllReservations();
        public Task<ReservationType> GetReservationById(Guid reservationId);
        public Task<List<ReservationType>> GetReservationsByUser(Guid userId);
        public Task<List<ReservationType>> GetReservationsBySportField(Guid sportFieldId);
        public Task<ReservationType> AddReservation(ReservationDto reservationToAdd);
        public Task<ReservationType> DeleteReservationById(Guid reservationId);
        public Task<ReservationType> ChangeStateById(Guid reservationId, ReservationStates newState);
    }
}
