using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OlympGuide.Application.Features.SportFieldProposal;
using OlympGuide.Domain.Features.SportFieldProposal;

namespace OlympGuide.Controllers
{
    [ApiController]
    [Authorize("access:admin")]
    [Authorize("access:user")]
    [Route("[controller]")]
    public class SportFieldProposalsController(ISportFieldProposalService service, IMapper mapper) : ControllerBase
    {
        private readonly IMapper _mapper = mapper;
        private readonly ISportFieldProposalService _service = service;

        [HttpGet("")]
        [Authorize("access:admin")]
        public async Task<List<SportFieldProposalDetailsDto>> GetAllSportFieldProposals([FromQuery] SportFieldProposalStates? state)
        {
            var list = await _service.GetAllSportFieldProposals(state);

            return _mapper.Map<List<SportFieldProposalType>, List<SportFieldProposalDetailsDto>>(list);
        }

        [HttpGet("{id}")]
        [Authorize("access:admin")]
        public async Task<SportFieldProposalDetailsDto> GetSportFieldProposalById(Guid id)
        {
            var sportFieldProposal = await _service.GetSportFieldProposalById(id);
            var sportFieldProposalDto = _mapper.Map<SportFieldProposalType, SportFieldProposalDetailsDto>(sportFieldProposal);

            return sportFieldProposalDto;
        }

        [HttpPost("")]
        [Authorize("access:admin")]
        public async Task<SportFieldProposalDetailsDto> AddSportFieldProposal([FromBody] SportFieldProposalDto sportFieldProposalToAdd)
        {

            var sportField = await _service.AddSportFieldProposal(sportFieldProposalToAdd);
            var sportFieldDto = _mapper.Map<SportFieldProposalType, SportFieldProposalDetailsDto>(sportField);

            return sportFieldDto;
        }

        [HttpPut("{id}")]
        [Authorize("access:admin")]
        public async Task<SportFieldProposalDetailsDto> ChangeStateById(Guid id, [FromBody] SportFieldProposalStates newState)
        {
            var sportFieldProposal = await _service.ChangeStateById(id,newState);
            var sportFieldDto = _mapper.Map<SportFieldProposalType, SportFieldProposalDetailsDto>(sportFieldProposal);

            return sportFieldDto;
        }
    }
}