using MediatR;
using Medicoz.Application.Contracts.Percistance;
using Medicoz.Application.Exceptions;
using Medicoz.Application.Features.Slider.Commands.CreateSlider;
using Medicoz.Application.Features.Slider.Commands.UpdateSlider;
using Medicoz.Application.Features.Slider.Queries.GetSliderByUniqueCode;
using Medicoz.Domain;
using Medicoz.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Medicoz.MVC.Controllers
{
    [Route("slider")]
    public class SliderController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ISliderRepository _sliderRepository;
        private readonly ITestRepository _testRepository;

        public SliderController(IMediator mediator, ISliderRepository sliderRepository, ITestRepository testRepository)
        {
            _mediator = mediator;
            _sliderRepository = sliderRepository;
            _testRepository = testRepository;
        }

        [HttpGet]
        public async Task<IActionResult> CreateAsync()
        {
            var newSlider = new TestModel
            {
                Title = new Dictionary<string, string>
            {
                { "az", "Salam" },
                { "ru", "Privet" }
            },
                Description = new Dictionary<string, string>
            {
                { "az", "Necesen" },
                { "ru", "Kak dela" }
            }
                // Other properties as needed
            };

            await _testRepository.AddAsync(newSlider);
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

        [HttpGet("update/{code}")]
        public async Task<IActionResult> Update(GetSliderByUniqueCodeQuery handler, string code)
        {
            handler.UniqueCode = code;
            var request = await _mediator.Send(handler);

            return View(request);
        }

        //[HttpGet("update/{code}")]
        //public async Task<IActionResult> Update(UpdateSliderCommand request, string code)
        //{
        //    var sliders = await _sliderRepository.GetByUniqueCode(code);
        //    request.EnglishContent = new();
        //    request.AzerbaijaniContent = new();

        //    foreach (var slider in sliders)
        //    {
        //        if (slider.Culture == "az")
        //        {
        //            request.EnglishContent.Quote = slider.Quote;
        //            request.RedirectUrl1 = slider.RedirectUrl;
        //            request.RedirectUrl2 = slider.RedirectUrl2;
        //            request.AzerbaijaniContent.ButtonName1 = slider.ButtonName;
        //            request.AzerbaijaniContent.ButtonName2 = slider.ButtonName2;
        //            request.AzerbaijaniContent.Description = slider.Description;
        //            request.AzerbaijaniContent.Quote = slider.Quote;
        //            request.AzerbaijaniContent.Title = slider.Title;
        //        }

        //        if (slider.Culture == "en-US")
        //        {
        //            request.EnglishContent.Quote = slider.Quote;
        //            request.RedirectUrl1 = slider.RedirectUrl;
        //            request.RedirectUrl2 = slider.RedirectUrl2;
        //            request.EnglishContent.ButtonName1 = slider.ButtonName;
        //            request.EnglishContent.ButtonName2 = slider.ButtonName2;
        //            request.EnglishContent.Description = slider.Description;
        //            request.EnglishContent.Quote = slider.Quote;
        //            request.EnglishContent.Title = slider.Title;
        //        }
        //    }
        //    return View(request);
        //}

        [HttpPost("update/{UniqueCodeForLocalisation}")]
        public async Task<IActionResult> Update(UpdateSliderCommand request)
        {
            try
            {
                var response = await _mediator.Send(request);
            }
            catch (CustomValidationException e)
            {
                foreach (var item in e.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(request);
            }
            return RedirectToAction("index", "home");
        }

    }
}
