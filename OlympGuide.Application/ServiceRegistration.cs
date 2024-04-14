using Microsoft.Extensions.DependencyInjection;
using OlympGuide.Application.Features.SportField;
using OlympGuide.Application.Features.SportFieldProposal;

namespace OlympGuide.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ISportFieldService, SportFieldService>();
            services.AddScoped<ISportFieldProposalService, SportFieldProposalService>();
        }
    }
}
