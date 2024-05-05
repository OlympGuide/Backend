using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OlympGuide.Domain.Features.Reservation;
using OlympGuide.Domain.Features.SportField;
using OlympGuide.Domain.Features.SportFieldProposal;
using OlympGuide.Domain.Features.TestData;
using OlympGuide.Domain.Features.User;
using OlympGuide.Infrastructre.Repositories;

namespace OlympGuide.Infrastructre
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OlympGuideDbContext>(options =>
                  options
                      .UseNpgsql(configuration.GetConnectionString("OlympGuideDB"))
                      .UseSnakeCaseNamingConvention()
                  );

            services.AddScoped<ISportFieldRepository, SportFieldRepository>();
            services.AddScoped<ISportFieldProposalRepository, SportFieldProposalRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITestDataRepository, TestDataRepository>();
        }
    }
}
