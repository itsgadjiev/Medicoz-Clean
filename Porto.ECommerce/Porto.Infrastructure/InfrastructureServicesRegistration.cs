using Medicoz.Application.Contracts.Email;
using Medicoz.Application.Contracts.Logging;
using Medicoz.Infrastructure.EmailService;
using Medicoz.Infrastructure.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Medicoz.Infrastructure;

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
