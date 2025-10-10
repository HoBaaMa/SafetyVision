using Asp.Versioning.ApiExplorer;
using Microsoft.OpenApi.Models;

namespace SafetyVision.Configurations
{
    public static class SwaggerRegistration
    {
        public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerDoc(description.GroupName, new OpenApiInfo
                    {
                        Title = "Safety Vision API",
                        Version = description.ApiVersion.ToString(),
                        Description = description.IsDeprecated ? " - DEPRECATED" : ""
                    });
                }
            });
            return services;
        }
    }
}
