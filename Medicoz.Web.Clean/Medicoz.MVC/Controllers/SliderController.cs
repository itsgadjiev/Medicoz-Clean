using MediatR;
using Medicoz.Application.Exceptions;
using Medicoz.Application.Features.Slider.Commands.CreateSlider;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Medicoz.MVC.Controllers
{
    [Route("slider")]
    public class SliderController : Controller
    {
        private readonly IMediator _mediator;

        public SliderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateSliderCommand createSliderCommand)
        {
            try
            {
                var response = await _mediator.Send(createSliderCommand);
            }
            catch (CustomValidationException e)
            {
                foreach (var item in e.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(createSliderCommand);
            }
            return RedirectToAction("index", "home");
        }
    }
}
