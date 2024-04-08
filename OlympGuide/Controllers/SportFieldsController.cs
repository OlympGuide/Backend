using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OlympGuide.Application.Features.SportField;
using OlympGuide.Domain.Features.SportField;

namespace OlympGuide.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SportFieldsController(ISportFieldService service, IMapper mapper) : ControllerBase
    {
        private readonly IMapper _mapper = mapper;
        private readonly ISportFieldService _service = service;

        [HttpGet("")]
        public async Task<List<SportFieldDto>> GetAllSportFields()
        {
            var list = await _service.GetAllSportFields();
            var result = _mapper.Map<List<SportFieldType>, List<SportFieldDto>>(list);

            return result;
        }

        [HttpGet("{id}")]
        public async Task<SportFieldDto> GetSportFieldById(Guid id)
        {
            var sportField = await _service.GetSportFieldById(id);
            var sportFieldDto = _mapper.Map<SportFieldType, SportFieldDto>(sportField);

            return sportFieldDto;
        }

        [HttpPost("")]
        public async Task<SportFieldDto> AddSportField([FromBody] CreateSportFieldRequestDto sportFieldToAdd)
        {

            var sportField = await _service.AddSportField(sportFieldToAdd);
            var sportFieldDto = _mapper.Map<SportFieldType, SportFieldDto>(sportField);

            return sportFieldDto;
        }
    }
}