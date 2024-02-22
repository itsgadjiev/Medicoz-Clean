using Medicoz.Application.Contracts.Payment;
using Medicoz.Domain;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.BillingPortal;
using Stripe.Checkout;

namespace Medicoz.MVC.Controllers
{
    public class PaymentController : Controller
    {

        public PaymentController(IConfiguration configuration)
        {

        }
        [HttpPost]
        public async Task<ActionResult> CreateCheckoutSession()
        {
            return RedirectToAction("Index");
        }

        
    }
}
