using Medicoz.Application.Contracts.Identity;
using Medicoz.Application.Contracts.Localisation;
using Medicoz.Application.Contracts.Percistance;
using Medicoz.Domain;
using Medicoz.MVC.ViewModels;
using Medicoz.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Medicoz.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly IDatabaseLocalisationRepository<Slider> _databaseLocalisationRepository;
        private readonly ILocalizationService<TestModel> _localizationService;
        private readonly ITestRepository _testRepository;

        public HomeController(IUserService userService,
            IDatabaseLocalisationRepository<Slider> databaseLocalisationRepository,
            ILocalizationService<TestModel> localizationService
          , ITestRepository testRepository)
        {
            _userService = userService;
            _databaseLocalisationRepository = databaseLocalisationRepository;
            _localizationService = localizationService;
            _testRepository = testRepository;
        }
        public async Task<IActionResult> Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel();
            var sliders = await _databaseLocalisationRepository.GetLocalizedEntities();
            homeViewModel.Sliders = sliders;

            homeViewModel.TestModels = await _testRepository.GetAllAsync();
            var testModelTitle = _localizationService.GetAllEntitiesLocalizedValues(nameof(TestModel.Title), "ru");
            var testModelDesc = _localizationService.GetAllEntitiesLocalizedValues(nameof(TestModel.Description), "ru");
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