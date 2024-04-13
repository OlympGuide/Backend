using Microsoft.Extensions.DependencyInjection;
using OlympGuide.Application.Features.SportField;
using OlympGuide.Application.Features.User;
using OlympGuide.Domain.Features.User;

namespace OlympGuide.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ISportFieldService, SportFieldService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthenticationProvider, Auth0AuthenticationProvider>();
        }
    }
}
