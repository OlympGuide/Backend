using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympGuide.Domain.Features.SportField
{
    public class SportFieldService(ISportFieldRepository repository) : ISportFieldService
    {
        private readonly ISportFieldRepository _repository = repository;

        public Task<SportField> AddSportField(SportField sportFieldToAdd)
        {
            return _repository.AddSportField(sportFieldToAdd);
        }

        public Task<List<SportField>> GetAllSportsField()
        {
            return _repository.GetAllSportsField();
        }

        public Task<SportField> GetSportFieldByID(Guid sportFieldID)
        {
            return _repository.GetSportFieldByID(sportFieldID);
        }
    }
}
