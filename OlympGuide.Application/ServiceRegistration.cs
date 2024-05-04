using Microsoft.Extensions.DependencyInjection;
using OlympGuide.Application.Features.Reservation;
using OlympGuide.Application.Features.SportField;
using OlympGuide.Application.Features.SportFieldProposal;
using OlympGuide.Application.Features.TestData;
using OlympGuide.Application.Features.User;
using OlympGuide.Domain.Features.User;

namespace OlympGuide.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ISportFieldService, SportFieldService>();
            services.AddScoped<ISportFieldProposalService, SportFieldProposalService>();
            services.AddScoped<IReservationService, ReservationService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITestDataService, TestDataService>();
        }
    }
}
