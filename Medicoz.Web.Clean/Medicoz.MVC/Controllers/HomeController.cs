using Medicoz.Application.Contracts.Identity;
using Medicoz.Application.Contracts.Localisation;
using Medicoz.Application.Contracts.Percistance;
using Medicoz.Domain;
using Medicoz.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Medicoz.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly IDatabaseLocalisationRepository<Slider> _databaseLocalisationRepository;
        private readonly ILocalizationService<OurService> _localizationService;
        private readonly IOurServicesRepository _ourServicesRepository;

        public HomeController(IUserService userService,
            IDatabaseLocalisationRepository<Slider> databaseLocalisationRepository,
            ILocalizationService<OurService> localizationService,
            IOurServicesRepository testRepository)
        {
            _userService = userService;
            _databaseLocalisationRepository = databaseLocalisationRepository;
            _localizationService = localizationService;
            _ourServicesRepository = testRepository;
        }
        public async Task<IActionResult> Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel();
            var sliders = await _databaseLocalisationRepository.GetLocalizedEntities();
            homeViewModel.Sliders = sliders;

            homeViewModel.OurServices = await _ourServicesRepository.GetAllAsync();
            var testModelTitle = _localizationService.GetAllEntitiesLocalizedValues(nameof(OurService.Title));
            var testModelDesc = _localizationService.GetAllEntitiesLocalizedValues(nameof(OurService.Description));
            homeViewModel.EntitiesLocalizedValuesTitle = testModelTitle;
            homeViewModel.EntitiesLocalizedValuesDesc = testModelDesc;

            return View(homeViewModel);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
    }
}