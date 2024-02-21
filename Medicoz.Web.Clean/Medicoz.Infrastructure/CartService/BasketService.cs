using Medicoz.Application.Contracts.Cart;
using Medicoz.Application.Contracts.Percistance;
using Medicoz.Domain;
using Microsoft.AspNetCore.Http;

namespace Medicoz.Infrastructure.CartService
{
    public class BasketService : IBasketService
    {
        private readonly IProductRepository _productRepository;

        public BasketService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Basket> GetBasketFromCookies(HttpContext context)
        {
            var basketString = context.Request.Cookies["basket"];
            if (string.IsNullOrEmpty(basketString))
            {
                Basket basket = new Basket();
                basket.BasketItems = new List<BasketItem>();
                return basket;
            }
            else
            {
                var basket = Newtonsoft.Json.JsonConvert.DeserializeObject<Basket>(basketString);
                foreach (var basketItem in basket.BasketItems)
                {
                    Product product =await _productRepository.GetByIdAsync(basketItem.ProductId);
                    basketItem.Product = product;
                }

                return basket;
            }
        }

        public void SaveBasketToCookies(HttpContext context, Basket basket)
        {
            var basketString = Newtonsoft.Json.JsonConvert.SerializeObject(basket); ;
            context.Response.Cookies.Append("basket", basketString, new CookieOptions
            {
                Expires = DateTimeOffset.Now.AddDays(7)
            });
        }
    }
}
