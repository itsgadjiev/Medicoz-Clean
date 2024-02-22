using Medicoz.Application.Contracts.Payment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NETCore.MailKit.Core;
using Stripe;
using Stripe.Checkout;

namespace Medicoz.Infrastructure.PaymentService
{
    public class PaymentService : IPaymentService
    {
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;

        public PaymentService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public StatusCodeResult Charge(HttpContext httpContext, long? amount, string orderDetail)
        {
            StripeConfiguration.ApiKey = _configuration.GetSection("Stripe")["SecretKey"];
            var domain = "https://localhost:7000";

            var options = new Stripe.Checkout.SessionCreateOptions
            {
                SuccessUrl = "https://example.com/success",
                LineItems = new List<Stripe.Checkout.SessionLineItemOptions>
                {
                  new Stripe.Checkout.SessionLineItemOptions
                  {
                      PriceData = new SessionLineItemPriceDataOptions
                       {
                            UnitAmount = amount,
                            Currency = "usd",
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                               Name = orderDetail,
                            }
                       },
                      Quantity=1
                  },
                },
                Mode = "payment",
                CancelUrl = domain + "/cancel",
            };

            var service = new Stripe.Checkout.SessionService();
            Stripe.Checkout.Session session = service.Create(options);

            httpContext.Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303);
        }
    }
}
