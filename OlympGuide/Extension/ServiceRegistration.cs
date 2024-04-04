using OlympGuide.Application.Features.SportField;
using System.Text.Json;

namespace OlympGuide.Extension
{
    public static class ServiceRegistration
    {
        public static void AddWebServices(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddCors();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
        public static void AddJsonPolicy(this IServiceCollection services)
        {
            services.AddControllers()
                      .AddJsonOptions(options =>
                      {
                          options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                      });
        }

        public static IWebHostBuilder AddCustomLogging(this IServiceCollection services, IWebHostBuilder builder)
        {
            return builder.ConfigureLogging(logging =>
            {
                logging.ClearProviders();
                logging.AddConsole();
            });
        }

    }
}
