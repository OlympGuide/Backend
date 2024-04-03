using Microsoft.EntityFrameworkCore;
using OlympGuide.Domain.Features.SportField;

namespace OlympGuide.Infrastructre.Repositories
{
    public class SportFieldRepository(OlympGuideDBContext context) : ISportFieldRepository
    {
        public async Task<List<SportField>> GetAllSportFields()
        {
            var sportFieldList = await context.SportFields
                .ToListAsync();

            return sportFieldList;
        }

        public async Task<SportField> GetSportFieldByID(Guid sportFieldID)
        {
            var sportField = await context.SportFields
                .SingleAsync(sf => sf.Id == sportFieldID);

            return sportField;
        }

        public async Task<SportField> AddSportField(SportField sportFieldToAdd)
        {
            await context.SportFields
                .AddAsync(sportFieldToAdd);

            await context.SaveChangesAsync();

            return sportFieldToAdd;
        }
    }
}
