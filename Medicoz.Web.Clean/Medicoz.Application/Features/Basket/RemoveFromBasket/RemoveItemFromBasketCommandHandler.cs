using MediatR;
using Medicoz.Application.Contracts.Cart;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicoz.Application.Features.Basket.RemoveFromBasket
{
    public class RemoveItemFromBasketCommandHandler : IRequestHandler<RemoveItemFromBasketCommand, Unit>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IBasketService _basketService;

        public RemoveItemFromBasketCommandHandler(IHttpContextAccessor httpContextAccessor, IBasketService basketService)
        {
            _httpContextAccessor = httpContextAccessor;
            _basketService = basketService;
        }

        public async Task<Unit> Handle(RemoveItemFromBasketCommand request, CancellationToken cancellationToken)
        {
            var basket = await _basketService.GetBasketFromCookies(_httpContextAccessor.HttpContext);

            var itemToRemove = basket.BasketItems.FirstOrDefault(x => x.Product.Id == request.ProductId);

            if (itemToRemove != null)
            {
                basket.BasketItems.Remove(itemToRemove);

                basket.BasketTotal = basket.BasketItems.Sum(item => item.ProductCount * item.Product.Price);

                _basketService.SaveBasketToCookies(_httpContextAccessor.HttpContext, basket);
                
            }
            return Unit.Value; 
        }
    }
}
