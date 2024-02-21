using Medicoz.Application.Contracts.Payment;
using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace Medicoz.MVC.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IPaymentService _paymentService;

        public PaymentController(IConfiguration configuration,IPaymentService paymentService)
        {
            _configuration = configuration;
            _paymentService = paymentService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Charge(string stripeEmail, string stripeToken, long amount)
        {
            _paymentService.Charge("ceyhun100203@gmail.com", 2000);
            return RedirectToAction("Index","home");
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
