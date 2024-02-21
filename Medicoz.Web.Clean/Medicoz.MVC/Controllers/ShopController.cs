using MediatR;
using Medicoz.Application.Contracts.Cart;
using Medicoz.Application.Contracts.Percistance;
using Medicoz.Application.Features.Products.Queries.GetAllProducts;
using Medicoz.Application.Features.Products.Queries.GetProductById;
using Medicoz.Application.Features.Products.Queries.GetProductByIdDetail;
using Medicoz.Domain;
using Medicoz.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Medicoz.MVC.Controllers
{
    [Route("medicoz/shop")]
    public class ShopController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IProductRepository _productRepository;
        private readonly IBasketRepository _basketRepository;
        private readonly IBasketItemRepository _basketItemRepository;
        private readonly IBasketService _basketService;

        public ShopController(IMediator mediator, IHttpContextAccessor httpContextAccessor, IProductRepository productRepository, 
            IBasketRepository basketRepository, IBasketItemRepository basketItemRepository,IBasketService basketService)
        {
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
            _productRepository = productRepository;
            _basketRepository = basketRepository;
            _basketItemRepository = basketItemRepository;
            _basketService = basketService;
        }

        public async Task<IActionResult> Index([FromQuery(Name = "sort")] string? sortField, string search)
        {
            var shopVM = new ShopViewModel
            {
                ProductDetailDTOs = await _mediator.Send(new GetAllProductsQuery(sortField, search)),
            };
            return View(shopVM);
        }

        [HttpGet("product/{id}")]
        public async Task<IActionResult> Detail(string id)
        {
            return View(await _mediator.Send(new GetProductByIdQueryDetail { Id = id }));
        }

        [HttpPost("product/{id}")]
        public async Task<IActionResult> AddToBasket(ProductDetailDTO productDetailDTO, string id)
        {
            var basket = _basketService.GetBasketFromCookies(Request.HttpContext);
            Product product = null;

            if (productDetailDTO.ProductId is null)
                product = await _productRepository.GetByIdAsync(id);
            else
                product = await _productRepository.GetByIdAsync(productDetailDTO.ProductId);

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
                    ProductCount = (productDetailDTO.Count != 0 ? productDetailDTO.Count : 1),
                    ProductId = product.Id
                };
                basket.BasketItems.Add(basketItem);
            }
            else
            {
                basketItem.ProductCount += (basketItem.ProductCount != 0 ? basketItem.ProductCount : 1);
            }

            _basketService.SaveBasketToCookies(Request.HttpContext,basket);

            return RedirectToAction("Index", "Home");
        }
    }
}
