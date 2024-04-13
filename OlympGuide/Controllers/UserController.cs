using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using OlympGuide.Application.Features.SportField;
using OlympGuide.Domain.Features.SportField;
using OlympGuide.Domain.Features.User;

namespace OlympGuide.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService service, IMapper mapper) : ControllerBase
    {
        private readonly IUserService _service = service;
        private readonly IMapper _mapper = mapper;

        [HttpGet("{token}")]
        public async Task<UserProfile> GetUser(string token)
        {
            
            try
            {
                var user = await _service.GetUserProfile(token);
                var result = _mapper.Map<UserProfile, UserProfileDto>(list);
            }
            catch (Exception ex)
            {

            }

            return result;
        }
    }
}
