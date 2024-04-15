using OlympGuide.Extension;
using OlympGuide.Infrastructre;
using OlympGuide.Application;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddWebServices();
builder.Services.AddJsonPolicy();
builder.Services.AddCustomLogging(builder.WebHost);
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceInfrastructure(builder.Configuration);
builder.Services.AddAuth(builder.Configuration);
builder.Services.AddAuthenticationProvider();

var app = builder.Build();

app.UseSwagger(app.Environment);
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.SetupCors();
app.AddExceptionHanlding();
app.ApplyDatabaseMigrations(app.Environment, app.Configuration);

app.Run();