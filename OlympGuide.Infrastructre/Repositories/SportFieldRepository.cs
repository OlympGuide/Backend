using Microsoft.EntityFrameworkCore;
using OlympGuide.Domain.Features.SportField;

namespace OlympGuide.Infrastructre.Repositories
{
    public class SportFieldRepository(OlympGuideDBContext context) : ISportFieldRepository
    {
        public async Task<List<SportFieldType>> GetAllSportFields()
        {
            var sportFieldList = await context.SportFields
                .ToListAsync();

            return sportFieldList;
        }

        public async Task<SportFieldType> GetSportFieldByID(Guid sportFieldID)
        {
            var sportField = await context.SportFields
                .SingleAsync(sf => sf.Id == sportFieldID);

            return sportField;
        }

        public async Task<SportFieldType> AddSportField(SportFieldType sportFieldToAdd)
        {
            await context.SportFields
                .AddAsync(sportFieldToAdd);

            await context.SaveChangesAsync();

            return sportFieldToAdd;
        }
    }
}
