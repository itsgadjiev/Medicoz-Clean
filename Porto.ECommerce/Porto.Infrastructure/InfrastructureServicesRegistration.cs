using Medicoz.Application.Contracts.Email;
using Medicoz.Application.Contracts.Localisation;
using Medicoz.Application.Contracts.Logging;
using Medicoz.Application.Localizer;
using Medicoz.Infrastructure.EmailService;
using Medicoz.Infrastructure.LocalizationService;
using Medicoz.Infrastructure.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;

namespace Medicoz.Infrastructure;

public static class InfrastructureServicesRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection serviceDescriptors, IConfiguration configuration)
    {
        serviceDescriptors
            .AddScoped<IEmailSender, EmailSender>()
            .AddTransient<IDatabaseLocalizationService, DatabaseLocalizationService>()
            .AddSingleton<IStringLocalizer, DatabaseStringLocalizer>()
            .AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

        return serviceDescriptors;
    }

}
