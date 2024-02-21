using MediatR;
using Medicoz.Application.Features.Products.Queries.GetAllProducts;
using Microsoft.AspNetCore.Mvc;

namespace Medicoz.MVC.ViewComponents
{
    public class SidebarViewComponent : ViewComponent
    {
        private readonly IMediator _mediator;

        public SidebarViewComponent(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var list = await _mediator.Send(new GetAllProductsQuery("newness", string.Empty));
            return View(list);
        }
    }
}
