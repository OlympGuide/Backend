using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OlympGuide.Application.Features.SportField;
using OlympGuide.Domain.Features.SportField;

namespace OlympGuide.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SportFieldController(ISportFieldService service, IMapper mapper) : ControllerBase
    {
        private readonly IMapper _mapper = mapper;
        private readonly ISportFieldService _service = service;

        [HttpGet("/")]
        public async Task<List<SportFieldDTO>> GetAllSportFields()
        {
            var list = await _service.GetAllSportFields();
            var result = _mapper.Map<List<SportFieldType>, List<SportFieldDTO>>(list);

            return result;
        }

        [HttpGet("/{id}")]
        public async Task<SportFieldDTO> GetSportFieldById(Guid id)
        {
            var sportField = await _service.GetSportFieldByID(id);
            var sportFieldDto = _mapper.Map<SportFieldType, SportFieldDTO>(sportField);

            return sportFieldDto;
        }

        [HttpPost("/")]
        public async Task<SportFieldDTO> AddSportField([FromBody] CreateSportFieldRequestDTO sportFieldToAdd)
        {

            var sportField = await _service.AddSportField(sportFieldToAdd);
            var sportFieldDto = _mapper.Map<SportFieldType, SportFieldDTO>(sportField);

            return sportFieldDto;
        }
    }
}