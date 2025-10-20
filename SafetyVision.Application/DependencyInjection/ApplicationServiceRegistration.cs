using Microsoft.Extensions.DependencyInjection;
using SafetyVision.Application.Interfaces;
using SafetyVision.Application.Services;
using System.Reflection;

namespace SafetyVision.Application.DependencyInjection
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IWorkerService, WorkerService>();
            services.AddScoped<ISafetyOfficerService, SafetyOfficerService>();
            services.AddScoped<IViolationService, ViolationService>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
