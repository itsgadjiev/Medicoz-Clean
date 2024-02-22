using MediatR;
using Medicoz.Application.Contracts.Cart;
using Medicoz.Application.Contracts.Email;
using Medicoz.Application.Contracts.Invoice;
using Medicoz.Application.Contracts.Payment;
using Medicoz.Application.Exceptions;
using Medicoz.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Medicoz.Application.Features.Order.PlaceOrder
{
    public class PlaceOrderCommandHandler : IRequestHandler<PlaceOrderCommand, Unit>
    {
        private readonly IPaymentService _paymentService;
        private readonly IBasketService _basketService;
        private readonly IEmailSender _emailService;
        private readonly IInvoiceCreator _invoiceCreator;

        public PlaceOrderCommandHandler(IPaymentService paymentService, IBasketService basketService, IEmailSender emailService,IInvoiceCreator invoiceCreator)
        {
            _paymentService = paymentService;
            _basketService = basketService;
            _emailService = emailService;
            _invoiceCreator = invoiceCreator;
        }
        public async Task<Unit> Handle(PlaceOrderCommand request, CancellationToken cancellationToken)
        {
            var basket = await _basketService.GetBasketFromCookies(request.HttpContext);
            if (basket is null)
            {
                throw new BadRequestException("Order", "No item in basket");
            }

            _paymentService.Charge(request.HttpContext, (long)basket.BasketTotal, "Medicoz");

            await _emailService.SendEmailAsync(request.Order.Email, "MEdicoz", "Sallam");

            Domain.Order order = new Domain.Order
            {
                Basket = basket,
                Email = request.Order.Email,
                FullName = request.Order.FullName,  
                Phone = request.Order.Phone,
                OrderStatus = Enums.OrderStatus.Success
            };

            var fileContentResult = _invoiceCreator.GenerateInvoice(order);

            byte[] fileContents = fileContentResult.FileContents;

            string desktopFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string filePath = Path.Combine(desktopFolderPath, $"Medicoz Invoice{DateTime.Now.ToString("d")+Guid.NewGuid().ToString().Substring(0,5)}.pdf");

            System.IO.File.WriteAllBytes(filePath, fileContents);

        
            return Unit.Value;
        }
    }
}
