using Medicoz.Application.Contracts.Identity;
using Medicoz.Application.Contracts.Localisation;
using Medicoz.Application.Contracts.Percistance;
using Medicoz.Application.Features.Slider.Queries.GetAllSliders;
using Medicoz.Domain;
using Medicoz.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace Medicoz.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly ILocalizationService<OurService> _localizationService;
        private readonly IOurServicesRepository _ourServicesRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly ILocalizationService<Slider> _localizationServiceSlider;
        private readonly ISliderRepository _sliderRepository;

        public HomeController(IUserService userService,
            ILocalizationService<OurService> localizationService,
            IOurServicesRepository testRepository,
            IDoctorRepository doctorRepository,
            ILocalizationService<Domain.Slider> localizationServiceSlider, ISliderRepository sliderRepository)
        {
            _userService = userService;
            _localizationService = localizationService;
            _ourServicesRepository = testRepository;
            _doctorRepository = doctorRepository;
            _localizationServiceSlider = localizationServiceSlider;
            _sliderRepository = sliderRepository;
        }
        public async Task<IActionResult> Index()
        {
            #region MyRegion
            HomeViewModel homeViewModel = new HomeViewModel();

            homeViewModel.OurServices = await _ourServicesRepository.GetAllAsync();
            var testModelTitle = _localizationService.GetAllEntitiesLocalizedValues(nameof(OurService.Title));
            var testModelDesc = _localizationService.GetAllEntitiesLocalizedValues(nameof(OurService.Description));
            homeViewModel.EntitiesLocalizedValuesTitle = testModelTitle;
            homeViewModel.EntitiesLocalizedValuesDesc = testModelDesc;
            homeViewModel.Doctors = await _doctorRepository.GetAllAsync();
            var sliders = await _sliderRepository.GetAllAsync();
            homeViewModel.SliderListDTOs = sliders.Select(x => new SliderListDTO
            {
                Description = _localizationServiceSlider.GetLocalizedValue(x.Id, nameof(Slider.Description)),
                Title = _localizationServiceSlider.GetLocalizedValue(x.Id, nameof(Slider.Title)),
                ButtnonName1 = _localizationServiceSlider.GetLocalizedValue(x.Id, nameof(Slider.ButtonName)),
                ButtonName2 = _localizationServiceSlider.GetLocalizedValue(x.Id, nameof(Slider.ButtonName2)),
                Quote = _localizationServiceSlider.GetLocalizedValue(x.Id, nameof(Slider.Quote)),
                ImageUrl = x.ImageUrl

            }).ToList();

            #endregion
            return View(homeViewModel);

        }

    }
}