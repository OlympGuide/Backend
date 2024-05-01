using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OlympGuide.Application.Features.Reservation;
using OlympGuide.Domain.Features.Reservation;

namespace OlympGuide.Controllers
{
    [ApiController]
    [Authorize("access:admin")]
    [Authorize("access:user")]
    [Route("[controller]")]
    public class ReservationsController(IReservationService service, IMapper mapper) : ControllerBase
    {
        private readonly IMapper _mapper = mapper;
        private readonly IReservationService _service = service;

        [HttpGet("")]
        [Authorize("access:user")]
        [Authorize("access:admin")]
        public async Task<List<ReservationDetailsDto>> GetAllReservations([FromQuery] Guid sportField, [FromQuery] Guid user)
        {
            List<ReservationType> list;
            if (!sportField.Equals(Guid.Empty))
            {
                list = await _service.GetReservationsBySportField(sportField);                
            }
            else if(!user.Equals(Guid.Empty))
            {
                list = await _service.GetReservationsByUser(user);
            }
            else
            {
                list = await _service.GetAllReservations();
            }
            return _mapper.Map<List<ReservationType>, List<ReservationDetailsDto>>(list);
        }

        [HttpGet("{id}")]
        [Authorize("access:user")]
        [Authorize("access:admin")]
        public async Task<ReservationDetailsDto> GetReservationById(Guid id)
        {
            var reservation = await _service.GetReservationById(id);
            var reservationDto = _mapper.Map<ReservationType, ReservationDetailsDto>(reservation);

            return reservationDto;
        }

        [HttpPost("")]
        [Authorize("access:user")]
        [Authorize("access:admin")]
        public async Task<ReservationDetailsDto> AddReservation([FromBody] ReservationDto reservationToAdd)
        {

            var reservation = await _service.AddReservation(reservationToAdd);
            var reservationDto = _mapper.Map<ReservationType, ReservationDetailsDto>(reservation);

            return reservationDto;
        }

        [HttpPut("{id}")]
        [Authorize("access:admin")]
        public async Task<ReservationDetailsDto> ChangeStateById(Guid id, [FromBody] ReservationStates newState)
        {
            var reservation = await _service.ChangeStateById(id, newState);
            var reservationDto = _mapper.Map<ReservationType, ReservationDetailsDto>(reservation);

            return reservationDto;
        }

        [HttpDelete("{id}")]
        [Authorize("access:user")]
        [Authorize("access:admin")]
        public async Task<ReservationDetailsDto> DeleteReservationById(Guid id)
        {
            var reservation = await _service.DeleteReservationById(id);
            var reservationDto = _mapper.Map<ReservationType, ReservationDetailsDto>(reservation);

            return reservationDto;
        }
    }
}