using MediatR;
using Medicoz.Application.Contracts.Cart;
using Medicoz.Application.Contracts.Email;
using Medicoz.Application.Contracts.Invoice;
using Medicoz.Application.Contracts.Payment;
using Medicoz.Application.Contracts.Percistance;
using Medicoz.Application.Exceptions;
using Medicoz.Domain.Common.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Medicoz.Application.Features.Order.PlaceOrder
{
    public class PlaceOrderCommandHandler : IRequestHandler<PlaceOrderCommand, StatusCodeResult>
    {
        private readonly IPaymentService _paymentService;
        private readonly IBasketService _basketService;
        private readonly IEmailSender _emailService;
        private readonly IInvoiceCreator _invoiceCreator;
        private readonly IOrderRepository _orderRepository;

        public PlaceOrderCommandHandler(IPaymentService paymentService, IBasketService basketService, IEmailSender emailService, IInvoiceCreator invoiceCreator, IOrderRepository orderRepository)
        {
            _paymentService = paymentService;
            _basketService = basketService;
            _emailService = emailService;
            _invoiceCreator = invoiceCreator;
            _orderRepository = orderRepository;
        }

        public async Task<StatusCodeResult> Handle(PlaceOrderCommand request, CancellationToken cancellationToken)
        {
            var basket = await _basketService.GetBasketFromCookies(request.HttpContext);
            if (basket is null)
            {
                throw new BadRequestException("Order", "No item in basket");
            }

            Domain.Order order = new Domain.Order
            {
                Id = Guid.NewGuid().ToString(),
                Basket = basket,
                BasketId =Guid.NewGuid().ToString(),
                Email = request.Order.Email,
                FullName = request.Order.FullName,
                Phone = request.Order.Phone,
                OrderStatus = OrderStatus.Success
            };

            //await _orderRepository.AddAsync(order);
            //await _orderRepository.SaveChangesAsync();

            await _emailService.SendEmailAsync(request.Order.Email, "Medicoz", $"Your order {order.Id}");
            var fileContentResult = _invoiceCreator.GenerateInvoice(order);

            byte[] fileContents = fileContentResult.FileContents;

            string desktopFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string filePath = Path.Combine(desktopFolderPath, $"Medicoz Invoice{DateTime.Now.ToString("d") + Guid.NewGuid().ToString().Substring(0, 5)}.pdf");

            System.IO.File.WriteAllBytes(filePath, fileContents);
            long total = (long)basket.BasketTotal;
            _basketService.DeleteBasket(request.HttpContext);

            return _paymentService.Charge(request.HttpContext, total, "Medicoz"); 
        }
    }
}
