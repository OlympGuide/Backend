using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OlympGuide.Application.Features.User;
using OlympGuide.Domain.Features.User;

namespace OlympGuide.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController(IUserService service, IMapper mapper) : ControllerBase
    {
        private readonly IUserService _service = service;
        private readonly IMapper _mapper = mapper;

        [HttpGet("Me")]
        public async Task<UserProfileDto> GetUser()
        {
            await _service.GetCurrentUserFromUserContext();
            var user = await _service.UpdateUser();
            return _mapper.Map<UserProfile, UserProfileDto>(user);
        }
    }
}
