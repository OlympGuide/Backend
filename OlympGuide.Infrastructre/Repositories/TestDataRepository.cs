using OlympGuide.Domain.Features.Reservation;
using OlympGuide.Domain.Features.SportField;
using OlympGuide.Domain.Features.SportFieldProposal;
using OlympGuide.Domain.Features.TestData;
using OlympGuide.Domain.Features.User;

namespace OlympGuide.Infrastructre.Repositories
{
    public class TestDataRepository(OlympGuideDbContext context) : ITestDataRepository
    {
        public static readonly string GuidBase = "274D2AE8-9853-4D26-B22E-FE296B77A";

        public async Task<int> CreateTestData(List<UserProfile> users, List<SportFieldType> sportFields, List<SportFieldProposalType> sportFieldProposals, List<ReservationType> reservations)
        {
            Task.WaitAll(
                context.Users.AddRangeAsync(users),
                context.SportFields.AddRangeAsync(sportFields),
                context.Reservations.AddRangeAsync(reservations),
                context.SportFieldProposals.AddRangeAsync(sportFieldProposals));

            var amountCreated = await context.SaveChangesAsync();
            return amountCreated;
        }

        public async Task<int> DeleteTestData()
        {
            var sportFieldProposalsToRemove = context.SportFieldProposals
                .ToList()
                .Where(sfp => sfp.Id.ToString().StartsWith(GuidBase, StringComparison.InvariantCultureIgnoreCase))
                .ToList();

            var sportFieldsToRemove = context.SportFields
                .ToList()
                .Where(sf => sf.Id.ToString().StartsWith(GuidBase, StringComparison.InvariantCultureIgnoreCase))
                .ToList();

            var reservationsToRemove = context.Reservations
                .ToList()
                .Where(r => r.Id.ToString().StartsWith(GuidBase, StringComparison.InvariantCultureIgnoreCase))
                .ToList();

            var usersToRemove = context.Users
                .ToList()
                .Where(u => u.Id.ToString().StartsWith(GuidBase, StringComparison.InvariantCultureIgnoreCase))
                .ToList();
            
            context.SportFieldProposals.RemoveRange(sportFieldProposalsToRemove);
            context.SportFields.RemoveRange(sportFieldsToRemove);
            context.Reservations.RemoveRange(reservationsToRemove);
            context.Users.RemoveRange(usersToRemove);

            var amountDeleted = await context.SaveChangesAsync();
            return amountDeleted;
        }
    }
}
