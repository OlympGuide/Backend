using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OlympGuide.Application.Features.SportField;

namespace OlympGuide.Domain.Features.SportField
{
    public interface ISportFieldService
    {
        public Task<List<SportField>> GetAllSportsField();
        public Task<SportField> GetSportFieldByID(Guid sportFieldID);
        public Task<SportField> AddSportField(CreateSportFieldRequestDTO sportFieldToAdd);
    }
}
