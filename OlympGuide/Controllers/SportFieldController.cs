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
        private readonly IMapper _mapper = mapper;
        private ISportFieldService _service = service;

        [HttpGet("GetAllSportFields")]
        public async Task<List<SportFieldDTO>> GetAllSportFields()
        {
            List<SportFieldType> list = await _service.GetAllSportsField();
            List<SportFieldDTO> result = _mapper.Map<List<SportFieldType>,List<SportFieldDTO>>(list);

            return result;
        }

        [HttpGet("GetSportFieldByID/{id}")]
        public async Task<SportFieldDTO> GetSportFieldByID(Guid id)
        {
            SportFieldType sportField = await _service.GetSportFieldByID(id);
            SportFieldDTO sportFieldDTO = _mapper.Map<SportFieldType, SportFieldDTO>(sportField);

            return sportFieldDTO;
        }

        [HttpPost("AddSportField")]
        public async Task<SportFieldDTO> AddSportField([FromBody] CreateSportFieldRequestDTO sportFieldToAdd)
        {

            SportFieldType sportField = await _service.AddSportField(sportFieldToAdd);
            SportFieldDTO sportFieldDTO = _mapper.Map<SportFieldType, SportFieldDTO>(sportField);

            return sportFieldDTO;
        }
    }
}