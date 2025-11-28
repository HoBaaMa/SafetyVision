using Asp.Versioning;

namespace SafetyVision.API.Configurations
{
    public static class ApiVersioningRegistration
    {
        public static IServiceCollection AddApiVersioningServices(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
                options.ApiVersionReader = ApiVersionReader.Combine(
                    new QueryStringApiVersionReader("version"),
                    new HeaderApiVersionReader("X-Version"),
                    new UrlSegmentApiVersionReader());

            })
                .AddApiExplorer(options =>
                {
                    options.GroupNameFormat = "'v'VVV";
                    options.SubstituteApiVersionInUrl = true;
                });
            return services;
        }
    }
}
