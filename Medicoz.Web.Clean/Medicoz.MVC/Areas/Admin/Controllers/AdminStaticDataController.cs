using MediatR;
using Medicoz.Application.Features.LocalizedStaticEntity.Commands.CreateLocalizedStaticEntity;
using Medicoz.Application.Features.LocalizedStaticEntity.Queries.GetAllStaticEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Medicoz.MVC.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/StaticData")]
    [Authorize(Roles = "Administrator")]

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
            var entites = await _mediator.Send(new GetAllStaticEntitiesQuery());
            return View(entites);
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
            return RedirectToAction("index", "AdminStaticData");
        }

       
    }
}
