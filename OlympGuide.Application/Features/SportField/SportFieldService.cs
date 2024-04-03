using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;
using OlympGuide.Application.Features.SportField;

namespace OlympGuide.Domain.Features.SportField
{
    public class SportFieldService(ISportFieldRepository repository) : ISportFieldService
    {
        private readonly ISportFieldRepository _repository = repository;

        public Task<SportField> AddSportField(CreateSportFieldRequestDTO sportFieldToAdd)
        {
            if (sportFieldToAdd != null && SportFieldValidation.CheckSportFieldRequestDTO(sportFieldToAdd))
            {
                SportField newSportField = new SportField()
                {
                    Name = sportFieldToAdd.Name,
                    Description = sportFieldToAdd.Description,
                    Longitude = sportFieldToAdd.Longitude,
                    Latitude = sportFieldToAdd.Latitude
                };

                return _repository.AddSportField(newSportField);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public Task<List<SportField>> GetAllSportFields()
        {
            return _repository.GetAllSportFields();
        }

        public async Task<SportField> GetSportFieldByID(Guid sportFieldID)
        {
            if (sportFieldID == Guid.Empty)
            {
                throw new ArgumentException();
            }
            SportField sportField = await _repository.GetSportFieldByID(sportFieldID);

            if (sportField == null)
            {
                throw new NoSportFieldFoundException();
            }
            return sportField;
        }
    }
}
