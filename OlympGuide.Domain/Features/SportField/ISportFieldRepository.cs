using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympGuide.Domain.Features.SportField
{
    public interface ISportFieldRepository
    {
        public Task<List<SportFieldType>> GetAllSportFields();
        public Task<SportFieldType> GetSportFieldByID(Guid sportFieldID);
        public Task<SportFieldType> AddSportField(SportFieldType sportFieldToAdd);
    }
}
