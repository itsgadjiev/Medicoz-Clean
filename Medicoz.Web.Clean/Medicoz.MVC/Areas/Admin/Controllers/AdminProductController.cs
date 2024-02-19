using MediatR;
using Medicoz.Application.Features.Products.Commands.AddCommand;
using Microsoft.AspNetCore.Mvc;

namespace Medicoz.MVC.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/product")]
    public class AdminProductController : Controller
    {
        private readonly IMediator _mediator;

        public AdminProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddProductCommand addProductCommand)
        {
            try
            {
               await _mediator.Send(addProductCommand);
            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
