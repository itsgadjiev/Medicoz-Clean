using Medicoz.Application.Contracts.Cart;
using Medicoz.Application.Contracts.Email;
using Medicoz.Application.Contracts.FileService;
using Medicoz.Application.Contracts.Invoice;
using Medicoz.Application.Contracts.Localisation;
using Medicoz.Application.Contracts.Logging;
using Medicoz.Application.Contracts.Payment;
using Medicoz.Application.Localizer;
using Medicoz.Infrastructure.CartService;
using Medicoz.Infrastructure.EmailService;
using Medicoz.Infrastructure.LocalizationService;
using Medicoz.Infrastructure.Logging;
using Medicoz.Infrastructure.StaticDataLocalisationService;
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
            .AddScoped<IBasketService, BasketService>()
            .AddSingleton<IInvoiceCreator,InvoiceService.InvoiceService>()
            .AddScoped<IPaymentService, PaymentService.PaymentService>()
            .AddScoped(typeof(IDatabaseLocalizationService<>), typeof(LocalizationService<>))
            .AddScoped(typeof(IStringLocalizer<>), typeof(DatabaseStringLocalizer<>))
            .AddScoped(typeof(ILocalizationService<>), typeof(LocalizationService<>))
            .AddScoped(typeof(IStaticDataLocalisationService<>), typeof(StaticDataLocalisationService<>))
            .AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

        return serviceDescriptors;
    }

}
