using MediatR;
using Medicoz.Application.Features.LocalizedStaticEntity.Commands.CreateLocalizedStaticEntity;
using Microsoft.AspNetCore.Mvc;

namespace Medicoz.MVC.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/StaticData")]
    public class AdminStaticDataController : Controller
    {
        private readonly IMediator _mediator;

        public AdminStaticDataController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var entity = await _mediator.Send(new );
            return View(entity);
        }

        [HttpGet("Create")]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateLocalizedStaticEntityCommand command)
        {
            var entity = await _mediator.Send(command);
            return View(entity);
        }

       
    }
}
