using MediatR;
using Medicoz.Application.Contracts.Cart;
using Medicoz.Application.Contracts.Payment;
using Medicoz.Application.Contracts.Percistance;
using Medicoz.Application.Features.Basket.RemoveFromBasket;
using Medicoz.Application.Features.Products.Queries.GetAllProducts;
using Medicoz.Application.Features.Products.Queries.GetProductById;
using Medicoz.Application.Features.Products.Queries.GetProductByIdDetail;
using Medicoz.Domain;
using Medicoz.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Medicoz.MVC.Controllers
{
    [Route("medicoz/shop")]
    public class ShopController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IProductRepository _productRepository;
        private readonly IBasketService _basketService;
        private readonly IPaymentService _paymentService;

        public ShopController(IMediator mediator, IHttpContextAccessor httpContextAccessor, IProductRepository productRepository,
             IBasketService basketService, IPaymentService paymentService)
        {
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
            _productRepository = productRepository;
            _basketService = basketService;
            _paymentService = paymentService;
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

        [HttpPost("add/product/{id}")]
        public async Task<IActionResult> AddToBasket(ProductDetailDTO productDetailDTO, string id)
        {
            Basket basket = await _basketService.GetBasketFromCookies(Request.HttpContext);
            Product product = null;

            if (productDetailDTO.ProductId is null)
                product = await _productRepository.GetByIdAsync(id);
            else
                product = await _productRepository.GetByIdAsync(productDetailDTO.ProductId);

            if (product == null)
                return NotFound();

            BasketItem basketItem = basket.BasketItems.FirstOrDefault(x => x.ProductId == product.Id);

            if (basketItem == null)
            {
                basketItem = new BasketItem()
                {
                    //ProductCount = 1,
                    ProductCount = (productDetailDTO.Count != 0 ? productDetailDTO.Count : 1),
                    ProductId = product.Id,
                };
                basket.BasketItems.Add(basketItem);
            }
            else
            {
                //basketItem.ProductCount += (basketItem.ProductCount != 0 ? basketItem.ProductCount : 1);
                basketItem.ProductCount += 1;
            }
            basketItem.BasketItemTotal = basketItem.ProductCount * product.Price;

            basket.BasketTotal = 0;
            foreach (var item in basket.BasketItems)
            {
                basket.BasketTotal += item.BasketItemTotal;
            }

            _basketService.SaveBasketToCookies(Request.HttpContext, basket);

            return RedirectToAction("Index", "shop");
        }

        [HttpPost("remove/product/{id}")]
        public async Task<IActionResult> RemoveFromBasket(string id)
        {
            await _mediator.Send(new RemoveItemFromBasketCommand { ProductId = id });

            return RedirectToAction("index", "basket");
        }

    }
}

