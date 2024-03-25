using Microsoft.AspNetCore.Mvc;
using OlympGuide.Domain.Features.SportField;
using System.Collections.Generic;

namespace OlympGuide.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SportFieldController(ISportFieldService service) : ControllerBase
    {
        private List<SportField> sportFields = new List<SportField>();

        [HttpGet]
        public Task<List<SportField>> GetAllSportFields()
        {
            return null;
        }

        [HttpGet]
        public Task<SportField> GetSportFieldByID(Guid id)
        {
            return null;
        }

        [HttpPost]
        public Task<SportField> AddSportField(SportField newSportField)
        {
            return null;
        }
    }
}