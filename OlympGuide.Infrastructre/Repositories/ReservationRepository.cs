using Microsoft.EntityFrameworkCore;
using OlympGuide.Domain.Features.Reservation;
using OlympGuide.Domain.Features.User;

namespace OlympGuide.Infrastructre.Repositories
{
    public class ReservationRepository(OlympGuideDbContext context) : IReservationRepository
    {
        public async Task<List<ReservationType>> GetAllReservations()
        {
            return await context.Reservations
                .ToListAsync();
        }

        public async Task<ReservationType> GetReservationById(Guid reservationId)
        {
            return await context.Reservations
                .SingleAsync(sf => sf.Id == reservationId);
        }

        public async Task<List<ReservationType>> GetReservationsByUser(UserProfile user)
        {
            return await context.Reservations
                .Where(sf => sf.User == user)
                .ToListAsync();
        }

        public async Task<List<ReservationType>> GetReservationsBySportField(Guid sportFieldId)
        {
            return await context.Reservations
                .Where(sf => sf.SportFieldId == sportFieldId)
                .ToListAsync();
        }

        public async Task<ReservationType> AddReservation(ReservationType reservationToAdd)
        {
            await context.Reservations
                .AddAsync(reservationToAdd);

            await context.SaveChangesAsync();

            return reservationToAdd;
        }

        public async Task<ReservationType> ChangeStateById(Guid reservationId, ReservationStates newState)
        {
            var reservation = await context.Reservations
                .SingleAsync(sf => sf.Id == reservationId);

            reservation.State = newState;
            context.Reservations.Update(reservation);
            await context.SaveChangesAsync();

            return reservation;

        }

        public async Task<ReservationType> ChangeReservation(ReservationType newReservation)
        {
            context.Reservations.Update(newReservation);
            await context.SaveChangesAsync();

            return newReservation;

        }

        public async Task<ReservationType> DeleteReservationById(Guid reservationId)
        {
            var reservation = await context.Reservations
                .SingleAsync(sf => sf.Id == reservationId);

            context.Reservations.Remove(reservation);

            await context.SaveChangesAsync();

            return reservation;
        }
    }
}
