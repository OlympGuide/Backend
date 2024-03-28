using System.ComponentModel.DataAnnotations;
using OlympGuide.Domain.Features.SportField;

namespace OlympGuide.Infrastructre
{
    public class SportFieldRepository : ISportFieldRepository
    {
        public async Task<List<SportField>> GetAllSportsField()
        {
            await using OlympGuideDBContext context = new OlympGuideDBContext();

            return context.SportFields
                .ToList();
        }

        public async Task<SportField> GetSportFieldByID(Guid sportFieldID)
        {
            await using OlympGuideDBContext context = new OlympGuideDBContext();

            return context.SportFields
                .Single(sf => sf.Id == sportFieldID);
        }

        public async Task<SportField> AddSportField(SportField sportFieldToAdd)
        {
            await using OlympGuideDBContext context = new OlympGuideDBContext();

            context.SportFields
                .Add(sportFieldToAdd);

            await context.SaveChangesAsync();

            return sportFieldToAdd;
        }
    }
}
