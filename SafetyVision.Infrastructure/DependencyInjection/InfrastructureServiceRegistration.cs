using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SafetyVision.Core.Interfaces;
using SafetyVision.Infrastructure.Data;
using SafetyVision.Infrastructure.Repositories;

namespace SafetyVision.Infrastructure.Utils
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(o =>
                o.UseSqlServer(configuration.GetConnectionString("AppDbContext")));


            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IWorkerRepository, WorkerRepository>();
            services.AddScoped<ISafetyOfficerRepository, SafetyOfficerRepository>();
            services.AddScoped<IViolationRepository, ViolationRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
