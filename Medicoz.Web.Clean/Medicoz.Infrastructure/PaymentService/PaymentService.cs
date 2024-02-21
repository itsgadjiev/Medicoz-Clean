using Medicoz.Application.Contracts.Payment;
using Microsoft.Extensions.Configuration;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicoz.Infrastructure.PaymentService
{
    public class PaymentService : IPaymentService
    {
        private readonly IConfiguration _configuration;

        public PaymentService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
     
        public void Charge(string stripeEmail,long amount)
        {
            try
            {
                string stripeSecretKey = _configuration.GetSection("Stripe")["SecretKey"];
                if (string.IsNullOrEmpty(stripeSecretKey))
                {
                    throw new ApplicationException("Stripe secret key not found in configuration.");
                }

                StripeConfiguration.ApiKey = stripeSecretKey;

                var options = new ChargeCreateOptions
                {
                    Amount = amount,
                    Currency = "usd",
                    Description = "Example charge",
                    Source = "4242424242424242",
                    ReceiptEmail = stripeEmail
                };

                var service = new ChargeService();

                var charge = service.Create(options);

            }
            catch (StripeException ex)
            {
                
                throw;
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
    }
}
