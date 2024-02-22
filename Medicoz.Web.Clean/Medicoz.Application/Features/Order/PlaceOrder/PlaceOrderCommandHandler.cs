﻿using MediatR;
using Medicoz.Application.Contracts.Cart;
using Medicoz.Application.Contracts.Email;
using Medicoz.Application.Contracts.Payment;
using Medicoz.Application.Exceptions;

namespace Medicoz.Application.Features.Order.PlaceOrder
{
    public class PlaceOrderCommandHandler : IRequestHandler<PlaceOrderCommand, Unit>
    {
        private readonly IPaymentService _paymentService;
        private readonly IBasketService _basketService;
        private readonly IEmailSender _emailService;

        public PlaceOrderCommandHandler(IPaymentService paymentService, IBasketService basketService, IEmailSender emailService)
        {
            _paymentService = paymentService;
            _basketService = basketService;
            _emailService = emailService;
        }
        public async Task<Unit> Handle(PlaceOrderCommand request, CancellationToken cancellationToken)
        {
            var basket = await _basketService.GetBasketFromCookies(request.HttpContext);
            if (basket is null)
            {
                throw new BadRequestException("Order", "No item in basket");
            }

            _paymentService.Charge(request.HttpContext, (long)basket.BasketTotal, "Medicoz");
            return Unit.Value;
        }
    }
}