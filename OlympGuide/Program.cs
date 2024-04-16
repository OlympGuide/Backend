using OlympGuide.Extension;
using OlympGuide.Infrastructre;
using OlympGuide.Application;
using MediatR;
using OlympGuide.Application.Features.SportFieldProposal;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddWebServices();
builder.Services.AddJsonPolicy();
builder.Services.AddCustomLogging(builder.WebHost);
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceInfrastructure(builder.Configuration);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddScoped<INotificationHandler<SportFieldProposalAcceptedEvent>, SportFieldProposalEventHandler>();

var app = builder.Build();

app.UseSwagger(app.Environment);
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.SetupCors();
app.ApplyDatabaseMigrations(app.Environment, app.Configuration);

app.Run();