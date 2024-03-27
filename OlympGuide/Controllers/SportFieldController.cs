using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OlympGuide.Application.Features.SportField;
using OlympGuide.Domain.Features.SportField;
using System.Collections.Generic;

namespace OlympGuide.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SportFieldController(ISportFieldService service, IMapper mapper) : ControllerBase
    {
        private IMapper _mapper = mapper;
        private ISportFieldService _service = service;

        [HttpGet]
        public async Task<List<SportFieldDTO>> GetAllSportFields()
        {
            List<SportField> list = await _service.GetAllSportsField();

            List<SportFieldDTO> result = new List<SportFieldDTO>();

            foreach (var item in list)
            {
                result.Add(_mapper.Map<SportFieldDTO>(item));
            }

            return result;
        }

        [HttpGet]
        public async Task<SportFieldDTO> GetSportFieldByID(Guid id)
        {
            SportField sportField = await _service.GetSportFieldByID(id);

            SportFieldDTO sportFieldDTO = _mapper.Map<SportFieldDTO>(sportField);

            return sportFieldDTO;
        }

        [HttpPost]
        public async Task<SportField> AddSportField(SportFieldDTO newSportField)
        {
            SportField sportField = _mapper.Map<SportField>(newSportField);

            return await _service.AddSportField(sportField);
        }
    }
}