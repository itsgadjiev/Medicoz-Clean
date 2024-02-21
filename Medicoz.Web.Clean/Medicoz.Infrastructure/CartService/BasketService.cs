using Medicoz.Application.Contracts.Cart;
using Medicoz.Domain;
using Microsoft.AspNetCore.Http;

namespace Medicoz.Infrastructure.CartService
{
    public class BasketService : IBasketService
    {
        public Basket GetBasketFromCookies(HttpContext context)
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
                var basket = Newtonsoft.Json.JsonConvert.DeserializeObject<Basket>(basketString); ;
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
