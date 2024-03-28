using OlympGuide.Domain.Features.SportField;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using OlympGuide.Infrastructre;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<ISportFieldService, SportFieldService>();
builder.Services.AddScoped<ISportFieldRepository, SportFieldRepository>();

builder.Services.AddDbContext<OlympGuideDBContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("OlympGuideDB")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
