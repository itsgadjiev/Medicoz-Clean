using MediatR;
using Medicoz.Application.Features.Products.Queries.GetAllProducts;
using Microsoft.AspNetCore.Mvc;

namespace Medicoz.MVC.Controllers
{
    public class ShopController : Controller
    {
        private readonly IMediator _mediator;

        public ShopController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index([FromQuery(Name = "sort")] string? sortField)
        {
            return View(await _mediator.Send(new GetAllProductsQuery(sortField)));
        }
    }
}
