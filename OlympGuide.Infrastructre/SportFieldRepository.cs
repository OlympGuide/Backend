using System.ComponentModel.DataAnnotations;
using OlympGuide.Domain.Features.SportField;

namespace OlympGuide.Infrastructre
{
    public class SportFieldRepository(OlympGuideDBContext context) : ISportFieldRepository
    {
        public Task<List<SportField>> GetAllSportsField()
        {
            return Task.FromResult(context.SportFields
                .ToList()); //TODO: Replace with proper async await
        }

        public Task<SportField> GetSportFieldByID(Guid sportFieldID)
        {
            return Task.FromResult(context.SportFields
                .Single(sf => sf.Id == sportFieldID)); //TODO: Replace with proper async await
        }

        public Task<SportField> AddSportField(SportField sportFieldToAdd)
        {
            context.SportFields
                .Add(sportFieldToAdd);

            return Task.FromResult(sportFieldToAdd); //TODO: Replace with proper async await
        }
    }
}
