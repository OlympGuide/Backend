using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OlympGuide.Domain.Features.SportField;
using OlympGuide.Infrastructre.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympGuide.Infrastructre
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OlympGuideDBContext>(options =>
                  options.UseNpgsql(configuration.GetConnectionString("OlympGuideDB")));

            services.AddScoped<ISportFieldRepository, SportFieldRepository>();
        }
    }
}
