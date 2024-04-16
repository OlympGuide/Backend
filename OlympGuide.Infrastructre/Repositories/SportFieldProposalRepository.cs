using Microsoft.EntityFrameworkCore;
using OlympGuide.Domain.Features.SportFieldProposal;

namespace OlympGuide.Infrastructre.Repositories
{
    public class SportFieldProposalRepository(OlympGuideDbContext context) : ISportFieldProposalRepository
    {
        public async Task<List<SportFieldProposalType>> GetAllSportFieldProposals()
        {
            var sportFieldProposalList = await context.SportFieldProposals
                .ToListAsync();

            return sportFieldProposalList;
        }

        public async Task<List<SportFieldProposalType>> GetAllOpenSportFieldProposals()
        {
            var sportFieldProposalList = await context.SportFieldProposals
                .Where(sf => sf.State == SportFieldProposalStates.Open)
                .ToListAsync();

            return sportFieldProposalList;
        }

        public async Task<SportFieldProposalType> GetSportFieldProposalById(Guid sportFieldProposalId)
        {
            var sportFieldProposal = await context.SportFieldProposals
                .SingleAsync(sf => sf.Id == sportFieldProposalId);

            return sportFieldProposal;
        }

        public async Task<SportFieldProposalType> AddSportFieldProposal(SportFieldProposalType sportFieldProposalToAdd)
        {
            await context.SportFieldProposals
                .AddAsync(sportFieldProposalToAdd);

            await context.SaveChangesAsync();

            return sportFieldProposalToAdd;
        }

        public async Task<SportFieldProposalType> ChangeStateById(Guid sportFieldProposalId, SportFieldProposalStates newState)
        {
            var sportFieldProposal = await context.SportFieldProposals
                .SingleAsync(sf => sf.Id == sportFieldProposalId);

            sportFieldProposal.State = newState;
            context.SportFieldProposals.Update(sportFieldProposal);
            await context.SaveChangesAsync();

            return sportFieldProposal;

        }

    }
}
