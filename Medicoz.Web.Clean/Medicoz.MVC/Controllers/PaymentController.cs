using MediatR;
using Medicoz.Application.Features.Order.PlaceOrder;
using Medicoz.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

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

            return await _mediator.Send(new PlaceOrderCommand
            {
                Order = basketViewModel.Order,
                HttpContext = HttpContext
            }); ;
        }
    }
}
