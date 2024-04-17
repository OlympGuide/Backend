using Microsoft.EntityFrameworkCore;
using OlympGuide.Domain.Features.SportFieldProposal;

namespace OlympGuide.Infrastructre.Repositories
{
    public class SportFieldProposalRepository(OlympGuideDbContext context) : ISportFieldProposalRepository
    {
        public async Task<List<SportFieldProposalType>> GetAllSportFieldProposals()
        {
            return await context.SportFieldProposals.ToListAsync();
        }

        public async Task<List<SportFieldProposalType>> GetAllOpenSportFieldProposals()
        {
            return await context.SportFieldProposals
                .Where(sf => sf.State == SportFieldProposalStates.Open)
                .ToListAsync();
        }

        public async Task<SportFieldProposalType> GetSportFieldProposalById(Guid sportFieldProposalId)
        {
            return await context.SportFieldProposals
                .SingleAsync(sf => sf.Id == sportFieldProposalId);
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
