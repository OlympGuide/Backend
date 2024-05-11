using OlympGuide.Domain.Features.Reservation;
using OlympGuide.Domain.Features.User;

namespace OlympGuide.Application.Features.Reservation
{
    public class ReservationService(IReservationRepository repository, IUserService userService) : IReservationService
    {
        private readonly IReservationRepository _repository = repository;
        private readonly IUserService _userService = userService;
        public async Task<List<ReservationType>> GetAllReservations()
        {
            var user = await _userService.GetCurrentUserFromUserContext();
            if(user.Roles.Contains(UserRole.Administrator))
            {
                return await _repository.GetAllReservations();
            }
            return await _repository.GetReservationsByUser(user);
        }

        public async Task<ReservationType> GetReservationById(Guid reservationId)
        {
            if (reservationId == Guid.Empty)
            {
                throw new ArgumentException("Guid must no be null");
            }

            try
            {
                return await _repository.GetReservationById(reservationId);
            }
            catch (InvalidOperationException)
            {
                throw new NoReservationFoundException(reservationId);
            }
        }

        public async Task<List<ReservationType>> GetReservationsBySportField(Guid sportFieldId)
        {
            if (sportFieldId == Guid.Empty)
            {
                throw new ArgumentException("Guid must no be null");
            }

            try
            {
                return await _repository.GetReservationsBySportField(sportFieldId);
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException(String.Format("Reservation for SportField with id: {0} was not found", sportFieldId.ToString()));
            }
        }

        public async Task<List<ReservationType>> GetReservationsByUser(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                throw new ArgumentException("Guid must no be null");
            }
            var user = await _userService.GetUserProfile(userId);
            try
            {
                return await _repository.GetReservationsByUser(user);
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException(String.Format("Reservation for User with id: {0} was not found", userId.ToString()));
            }
        }

        public async Task<ReservationType> AddReservation(ReservationDto reservationToAdd)
        {
            var user = await _userService.GetCurrentUserFromUserContext();

            var newReservation = new ReservationType()
            {
                User = user,
                SportFieldId = reservationToAdd.SportFieldId,
                Start = reservationToAdd.Start,
                End = reservationToAdd.End,
                State = ReservationStates.Open
            };

            return await _repository.AddReservation(newReservation);
        }

        public async Task<ReservationType> ChangeStateById(Guid reservationId, ReservationStates newState)
        {
            if (reservationId == Guid.Empty)
            {
                throw new ArgumentException("Guid must no be Empty");
            }
            try
            {
                return await _repository.ChangeStateById(reservationId, newState);
            }
            catch (InvalidOperationException)
            {
                throw new NoReservationFoundException(reservationId);
            }
        }

        public async Task<ReservationType> ChangeReservationById(Guid reservationId, ReservationDto reservationToChange)
        {
            if (reservationId == Guid.Empty)
            {
                throw new ArgumentException("Guid must no be Empty");
            }
            try
            {
                var reservation = await _repository.GetReservationById(reservationId);
                reservation.Start = reservationToChange.Start;
                reservation.End = reservationToChange.End;
                reservation.SportFieldId = reservationToChange.SportFieldId;

                return await _repository.ChangeReservation(reservation);
            }
            catch (InvalidOperationException)
            {
                throw new NoReservationFoundException(reservationId);
            }
        }

        public async Task<ReservationType> DeleteReservationById(Guid reservationId)
        {
            if (reservationId == Guid.Empty)
            {
                throw new ArgumentException("Guid must no be null");
            }

            try
            {
                return await _repository.DeleteReservationById(reservationId);
            }
            catch (InvalidOperationException)
            {
                throw new NoReservationFoundException(reservationId);
            }

        }

    }
}
