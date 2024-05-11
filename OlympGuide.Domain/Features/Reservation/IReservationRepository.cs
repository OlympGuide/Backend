using OlympGuide.Domain.Features.User;

namespace OlympGuide.Domain.Features.Reservation
{
    public interface IReservationRepository
    {
        public Task<List<ReservationType>> GetAllReservations();
        public Task<ReservationType> GetReservationById(Guid reservationId);
        public Task<List<ReservationType>> GetReservationsByUser(UserProfile user);
        public Task<List<ReservationType>> GetReservationsBySportField(Guid sportFieldId);
        public Task<ReservationType> AddReservation(ReservationType reservationToAdd);
        public Task<ReservationType> DeleteReservationById(Guid reservationId);
        public Task<ReservationType> ChangeReservation(ReservationType reservation);
        public Task<ReservationType> ChangeStateById(Guid reservationId, ReservationStates newState);
    }
}
