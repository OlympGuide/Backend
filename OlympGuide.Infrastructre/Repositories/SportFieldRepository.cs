using Microsoft.EntityFrameworkCore;
using OlympGuide.Domain.Features.SportField;

namespace OlympGuide.Infrastructre.Repositories
{
    public class SportFieldRepository(OlympGuideDbContext context) : ISportFieldRepository
    {
        public async Task<List<SportFieldType>> GetAllSportFields()
        {
            var sportFieldList = await context.SportFields
                .ToListAsync();

            return sportFieldList;
        }

        public async Task<SportFieldType> GetSportFieldById(Guid sportFieldId)
        {
            var sportField = await context.SportFields
                .SingleAsync(sf => sf.Id == sportFieldId);

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
