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
        public async Task<List<SportFieldDto>> GetAllSportFields([FromQuery] SportFieldCategory? category)
        {

            var sportfields = category != null ? await _service.GetSportFieldsByCategory((SportFieldCategory)category) : await _service.GetAllSportFields();
            var result = _mapper.Map<List<SportFieldType>, List<SportFieldDto>>(sportfields);
            return result;
        }

        [HttpGet("{id}")]
        public async Task<SportFieldDto> GetSportFieldById(Guid id)
        {
            var sportField = await _service.GetSportFieldById(id);
            var sportFieldDto = _mapper.Map<SportFieldType, SportFieldDto>(sportField);

            return sportFieldDto;
        }
    }
}