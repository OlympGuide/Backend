using Microsoft.EntityFrameworkCore;
using OlympGuide.Domain.Features.SportField;

namespace OlympGuide.Infrastructre.Repositories
{
    public class SportFieldRepository(OlympGuideDbContext context) : ISportFieldRepository
    {
        public async Task<List<SportFieldType>> GetAllSportFields()
        {
            return await context.SportFields
                .ToListAsync();
        }

        public async Task<SportFieldType> GetSportFieldById(Guid sportFieldId)
        {
            return await context.SportFields
                .SingleAsync(sf => sf.Id == sportFieldId);
        }

        public async Task<SportFieldType> AddSportField(SportFieldType sportFieldToAdd)
        {
            await context.SportFields
                .AddAsync(sportFieldToAdd);

            await context.SaveChangesAsync();

            return sportFieldToAdd;
        }

        public async Task<List<SportFieldType>> GetSportFieldsByCategory(SportFieldCategory catergory)
        {
            return await context.SportFields
                .Where(sf => sf.Category == catergory)
                .ToListAsync();
        }
    }
}
