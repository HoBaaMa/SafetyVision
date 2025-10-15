using Asp.Versioning.ApiExplorer;
using SafetyVision.Application.DependencyInjection;
using SafetyVision.Configurations;
using SafetyVision.Infrastructure.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services
    .AddApiVersioningServices()
    .AddSwaggerServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddApplicationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
        foreach (var description in provider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint(
                $"swagger/{description.GroupName}/swagger.json",
                $"Safety Vision API {description.GroupName.ToUpperInvariant()}");
        };
        options.RoutePrefix = string.Empty; // Set Swagger UI at the app's root
    });
}

app.UseRouting();


app.UseHttpsRedirection();

app.MapControllers();
app.Run();
