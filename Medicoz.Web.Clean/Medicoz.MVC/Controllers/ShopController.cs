using MediatR;
using Medicoz.Application.Contracts.Percistance;
using Medicoz.Application.Features.Basket.AddToBasket;
using Medicoz.Application.Features.Products.Queries.GetAllProducts;
using Medicoz.Application.Features.Products.Queries.GetProductById;
using Medicoz.Application.Features.Products.Queries.GetProductByIdDetail;
using Medicoz.Domain;
using Medicoz.MVC.ViewModels;
using Medicoz.Persistence.Database;
using Medicoz.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Medicoz.MVC.Controllers
{
    public class ShopController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IProductRepository _productRepository;
        private readonly IBasketRepository _basketRepository;
        private readonly IBasketItemRepository _basketItemRepository;

        public ShopController(IMediator mediator, IHttpContextAccessor httpContextAccessor, IProductRepository productRepository,IBasketRepository basketRepository,IBasketItemRepository basketItemRepository)
        {
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
            _productRepository = productRepository;
            _basketRepository = basketRepository;
            _basketItemRepository = basketItemRepository;
        }
        public async Task<IActionResult> Index([FromQuery(Name = "sort")] string? sortField, string search)
        {
            var list = await _mediator.Send(new GetAllProductsQuery("newness", string.Empty));
            var shopVM = new ShopViewModel
            {
                NewProductDetailDTOs = list.Take(3).ToList(),
                ProductDetailDTOs = await _mediator.Send(new GetAllProductsQuery(sortField, search)),
            };
            return View(shopVM);
        }

        public async Task<IActionResult> Detail(string id)
        {
            return View(await _mediator.Send(new GetProductByIdQueryDetail { Id = id }));
        }

        [HttpPost("addToBastek")]
        public async Task<IActionResult> AddToBasket(ProductDetailDTO productDetailDTO, string id)
        {
            var basket = GetBasketFromCookies();
            Product product = null;

            if (productDetailDTO.ProductId is null)
                await _productRepository.GetByIdAsync(id);
            else
                await _productRepository.GetByIdAsync(productDetailDTO.ProductId);
           
            if (product == null)
                return NotFound();
            

            BasketItem basketItem = _basketItemRepository
               .FirstOrDefault(x =>
               x.ProductId == product.Id
               && x.Basket == basket);

            if (basketItem == null)
            {
                basketItem = new BasketItem()
                {
                    ProductCount = (productDetailDTO.Count != null ? productDetailDTO.Count : 1),
                    ProductId = product.Id
                };
                basket.BasketItems.Add(basketItem);
            }
            else
            {
                basketItem.ProductCount += (basketItem.ProductCount != null ? basketItem.ProductCount : 1);
            }

            SaveBasketToCookies(basket);

            return RedirectToAction("Index", "Home");
        }

        private Basket GetBasketFromCookies()
        {
            var basketString = Request.Cookies["basket"];
            if (string.IsNullOrEmpty(basketString))
            {
                return new Basket();
            }
            else
            {
                var basket = JsonConvert.DeserializeObject<Basket>(basketString);
                return basket;
            }
        }

        private void SaveBasketToCookies(Basket basket)
        {
            var basketString = JsonConvert.SerializeObject(basket);
            Response.Cookies.Append("basket", basketString, new CookieOptions
            {
                Expires = DateTimeOffset.Now.AddDays(7)
            });
        }
    }
}
