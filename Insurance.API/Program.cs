using Insurance.API.Configurations;
using Insurance.Application.IServices;
using Insurance.Application.Services;
using Insurance.Core.IRepositories;
using Insurance.Core.IServices;
using Insurance.Infra.Repositories;
using Insurance.Infra.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    ApplicationName = typeof(Program).Assembly.FullName,
    ContentRootPath = Path.GetFullPath(Directory.GetCurrentDirectory()),
    WebRootPath = Path.GetFullPath(Directory.GetCurrentDirectory()),
    Args = args
});

builder.Services.AddDatabaseSetup(builder.Configuration);

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});

builder.Services.AddEndpointsApiExplorer();


// Repositories
builder.Services.AddScoped<IInsuranceRequestRepository, InsuranceRequestRepository>();
builder.Services.AddScoped<IInsuranceCoverageRepository, InsuranceCoverageRepository>();

// Services
builder.Services.AddScoped<IInsuranceCalculatorService, InsuranceCalculatorService>();
builder.Services.AddScoped<IInsuranceService, InsuranceService>();

builder.Services.AddMemoryCache();

builder.Services.AddHttpContextAccessor();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(options =>
{
    options.AddPolicy("MyAPI",
      builder =>
      {
          builder.WithOrigins("*");
          builder.WithHeaders("*");
          builder.WithMethods("*");
      });
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();