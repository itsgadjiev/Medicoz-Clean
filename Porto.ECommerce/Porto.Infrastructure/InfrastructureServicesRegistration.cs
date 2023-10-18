
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Porto.Application.Contracts.Email;
using Porto.Application.Contracts.Logging;
using Porto.Infrastructure.EmailService;
using Porto.Infrastructure.Logging;

namespace Porto.Infrastructure;

public static class InfrastructureServicesRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection serviceDescriptors, IConfiguration configuration)
    {
        serviceDescriptors
            .AddScoped<IEmailSender, EmailSender>()
            .AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

        return serviceDescriptors;
    }

}
