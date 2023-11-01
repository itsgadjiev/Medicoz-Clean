using Medicoz.Application.Localizer;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Medicoz.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddScoped<DatabaseStringLocalizer>();

        return services;
    }
}
