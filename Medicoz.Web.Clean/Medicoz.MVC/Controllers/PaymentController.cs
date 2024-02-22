using MediatR;
using Medicoz.Application.Contracts.Payment;
using Medicoz.Application.Features.Order.PlaceOrder;
using Medicoz.Domain;
using Medicoz.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.BillingPortal;
using Stripe.Checkout;

namespace Medicoz.MVC.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IMediator _mediator;

        public PaymentController(IConfiguration configuration, IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult> CreateCheckoutSession(BasketViewModel basketViewModel)
        {
            await _mediator.Send(new PlaceOrderCommand
            {
                Order = basketViewModel.Order,
                HttpContext = HttpContext
            });
            return RedirectToAction("Index","shop");
        }
    }
}
