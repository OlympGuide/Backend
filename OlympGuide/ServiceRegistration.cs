using OlympGuide.Features.User;
using OlympGuide.Application.Features.User;

namespace OlympGuide
{
    public static class ServiceRegistration
    {
        public static void AddUserContext(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<IUserContext, UserContext>();
        }
    }
}
