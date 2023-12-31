﻿using Medicoz.Application.Contracts.Email;
using Medicoz.Application.Contracts.FileService;
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
            .AddScoped<IFileService, FileService.FileService>()
            .AddScoped(typeof(IDatabaseLocalizationService<>), typeof(LocalizationService<>))
            .AddScoped(typeof(IStringLocalizer<>), typeof(DatabaseStringLocalizer<>))
            .AddScoped(typeof(ILocalizationService<>), typeof(LocalizationService<>))
            .AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

        return serviceDescriptors;
    }

}
