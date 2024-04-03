using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OlympGuide.Application.Features.SportField;
using OlympGuide.Domain.Features.SportField;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

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
            List<SportField> list = await _service.GetAllSportFields();
            List<SportFieldDTO> result = _mapper.Map<List<SportField>,List<SportFieldDTO>>(list);

            return result;
        }

        [HttpGet("GetSportFieldByID/{id}")]
        public async Task<SportFieldDTO> GetSportFieldByID(Guid id)
        {
            
            SportField sportField = await _service.GetSportFieldByID(id);
            SportFieldDTO sportFieldDTO = _mapper.Map<SportField,SportFieldDTO>(sportField);

            return sportFieldDTO;
        }

        [HttpPost("AddSportField")]
        public async Task<SportFieldDTO> AddSportField([FromBody] CreateSportFieldRequestDTO sportFieldToAdd)
        {

            SportField sportField = await _service.AddSportField(sportFieldToAdd);
            SportFieldDTO sportFieldDTO = _mapper.Map<SportField, SportFieldDTO>(sportField);

            return sportFieldDTO;
        }
    }
}