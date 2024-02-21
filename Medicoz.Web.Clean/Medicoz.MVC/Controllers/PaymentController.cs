using Medicoz.Application.Contracts.Payment;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.BillingPortal;
using Stripe.Checkout;

namespace Medicoz.MVC.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IPaymentService _paymentService;

        public PaymentController(IConfiguration configuration, IPaymentService paymentService)
        {
            _configuration = configuration;
            _paymentService = paymentService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> CreateCheckoutSession()
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
                            UnitAmount = 1233,
                            Currency = "usd",
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                               Name = "Salamaleykuma",
                            }
                       },
                      Quantity=1
                     },
                  
                },
                Mode = "payment",
            };


            var service = new Stripe.Checkout.SessionService();
            Stripe.Checkout.Session session = service.Create(options);

            Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303);
        }

        public IActionResult PaymentSuccess()
        {
            return View();
        }

        public IActionResult PaymentError()
        {
            return View();
        }
    }
}
