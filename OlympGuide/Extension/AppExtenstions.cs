using Microsoft.EntityFrameworkCore;
using OlympGuide.Infrastructre;

namespace OlympGuide.Extension
{
    public static class AppExtenstions
    {
        public static void UseSwagger(this IApplicationBuilder app, IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
        }
        public static void ApplyDatabaseMigrations(this IApplicationBuilder app, IHostEnvironment env, IConfiguration configuration)
        {
            var loggerFactory = app.ApplicationServices.GetRequiredService<ILoggerFactory>();
            var logger = loggerFactory.CreateLogger("AppExtenstions");

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<OlympGuideDbContext>();
                logger.LogInformation("Apply migration to database");
                logger.LogInformation($"Environment: {env.EnvironmentName}");
                var connectionstring = configuration.GetConnectionString("OlympGuideDB");
                logger.LogInformation($"DB: {connectionstring}");

                db.Database.Migrate();
            }

        }
        public static void SetupCors(this IApplicationBuilder app)
        {
            app.UseCors(option => option.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
        }
        
    }
}
