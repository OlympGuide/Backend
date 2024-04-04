using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OlympGuide.Domain.Features.SportField;


namespace OlympGuide.Application.Features.SportField
{
    public interface ISportFieldService
    {
        public Task<List<SportFieldType>> GetAllSportsField();
        public Task<SportFieldType> GetSportFieldByID(Guid sportFieldID);
        public Task<SportFieldType> AddSportField(CreateSportFieldRequestDTO sportFieldToAdd);
    }
}
