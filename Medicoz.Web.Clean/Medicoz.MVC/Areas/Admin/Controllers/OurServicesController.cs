using MediatR;
using Medicoz.Application.Contracts.Localisation;
using Medicoz.Application.Contracts.Percistance;
using Medicoz.Application.Exceptions;
using Medicoz.Application.Features.OurServices.Commands.AddOurService;
using Medicoz.Application.Features.OurServices.Commands.UpdateOurService;
using Medicoz.Application.Features.OurServices.Queries.GetOurServices;
using Medicoz.Application.Features.Slider.Commands.CreateSlider;
using Medicoz.Domain;
using Medicoz.MVC.Areas.Admin.ViewModels;
using Medicoz.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Medicoz.MVC.Areas.Admin.Controllers
{
    [Route("admin/services")]
    [Area("admin")]
    public class OurServicesController : Controller
    {
        private readonly ILocalizationService<OurService> _localizationService;
        private readonly IOurServicesRepository _ourServicesRepository;
        private readonly IMediator _mediator;

        public OurServicesController(ILocalizationService<OurService> localizationService, IOurServicesRepository ourServicesRepository, IMediator mediator)
        {
            _localizationService = localizationService;
            _ourServicesRepository = ourServicesRepository;
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            OurServicesListVM ourServicesListVM = new OurServicesListVM();

            var ourServices = await _ourServicesRepository.GetAllAsync();
            var testModelTitle = _localizationService.GetAllEntitiesLocalizedValues(nameof(OurService.Title));
            var testModelDesc = _localizationService.GetAllEntitiesLocalizedValues(nameof(OurService.Description));

            ourServicesListVM.OurServices = ourServices;
            ourServicesListVM.Title = testModelTitle;
            ourServicesListVM.Desc = testModelDesc;
            return View(ourServicesListVM);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(AddOurServiceCommand addOurServiceCommand)
        {
            try
            {
                await _mediator.Send(addOurServiceCommand);
            }
            catch (CustomValidationException e)
            {
                foreach (var item in e.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(addOurServiceCommand);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("update/{id}")]
        public async Task<IActionResult> Update(int id)
        {
            var query = new GetOurServiceByIdQuery { Id  = id };
            var serviceViewModel = await _mediator.Send(query);

            if (serviceViewModel == null)
            {
                return NotFound(); 
            }

            return View(serviceViewModel);
        }

        [HttpPost("update/{id}")]
        public async Task<IActionResult> UpdateAsync(UpdateOurServiceCommand updateOurServiceCommand)
        {
            await _mediator.Send(updateOurServiceCommand);
            return RedirectToAction(nameof(Index));
        }
    }
}
