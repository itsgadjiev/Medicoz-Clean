using Medicoz.Application.Contracts.Cart;
using Medicoz.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Medicoz.MVC.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }
        public async Task<IActionResult> Index()
        {
            BasketViewModel basketViewModel = new BasketViewModel();
            basketViewModel.Basket = await _basketService.GetBasketFromCookies(HttpContext);
            
            return View(basketViewModel);
        }
    }
}
