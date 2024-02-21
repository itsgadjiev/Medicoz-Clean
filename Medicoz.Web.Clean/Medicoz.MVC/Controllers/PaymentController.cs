using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace Medicoz.MVC.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IConfiguration _configuration;

        public PaymentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Charge(string stripeEmail, string stripeToken)
        {
            StripeConfiguration.ApiKey = _configuration.GetSection("Stripe")["SecretKey"];

            var options = new ChargeCreateOptions
            {
                Amount = 2000,
                Currency = "usd",
                Description = "Example charge",
                Source = stripeToken, 
                ReceiptEmail = stripeEmail
            };

            var service = new ChargeService();
            try
            {
                var charge = service.Create(options);
                return RedirectToAction("PaymentSuccess");
            }
            catch (StripeException ex)
            {
                ViewBag.Error = ex.Message;
                return View("PaymentError");
            }
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
