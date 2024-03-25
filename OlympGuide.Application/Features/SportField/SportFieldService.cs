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
            throw new NotImplementedException();
        }

        public Task<List<SportField>> GetAllSportsField()
        {
            throw new NotImplementedException();
        }

        public Task<SportField> GetSportFieldByID(Guid sportFieldID)
        {
            throw new NotImplementedException();
        }
    }
}
