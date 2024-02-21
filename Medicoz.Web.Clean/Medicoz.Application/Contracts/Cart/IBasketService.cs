using Medicoz.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicoz.Application.Contracts.Cart
{
    public interface IBasketService
    {
        Task<Basket> GetBasketFromCookies(HttpContext context);
        void SaveBasketToCookies(HttpContext context, Basket basket);
    }
}
