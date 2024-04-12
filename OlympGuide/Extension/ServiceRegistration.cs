using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using OlympGuide.Authentication;
using System.Security.Claims;
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

        public static void AddCustomLogging(this IServiceCollection services, IWebHostBuilder builder)
        {
            builder.ConfigureLogging(logging =>
            {
                logging.ClearProviders();
                logging.AddConsole();
            });
        }
        public static void AddAuth(this IServiceCollection services, IConfiguration configuration)
        {
            var domain = $"https://{configuration["Auth0:Domain"]}/";
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = $"https://{configuration["Auth0:Domain"]}/";
                    options.Audience = configuration["Auth0:Audience"];
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        NameClaimType = ClaimTypes.NameIdentifier
                    };
                });

            services
              .AddAuthorization(options =>
              {
                  options.AddPolicy(
                    "read:public",
                    policy => policy.Requirements.Add(
                      new HasScopeRequirement("read:public", domain)
                    )
                  );
                  options.AddPolicy(
                    "access:user",
                    policy => policy.Requirements.Add(
                      new HasScopeRequirement("access:user", domain)
                    )
                  );
                  options.AddPolicy(
                  "access:admin",
                  policy => policy.Requirements.Add(
                    new HasScopeRequirement("access:admin", domain)
                  )
                );
              });
              
            services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();
        }
    }
}
