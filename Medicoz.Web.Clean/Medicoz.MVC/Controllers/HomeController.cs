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

        public HomeController(IUserService userService,
            IDatabaseLocalisationRepository<Slider> databaseLocalisationRepository,
            ILocalizationService<TestModel> localizationService )
        {
            _userService = userService;
            _databaseLocalisationRepository = databaseLocalisationRepository;
            _localizationService = localizationService;
        }
        public async Task<IActionResult> Index()
        {
            var sliders = await _databaseLocalisationRepository.GetLocalizedEntities();
            var test = _localizationService.GetAllEntitiesLocalizedValues("ru");


            HomeViewModel homeViewModel = new HomeViewModel();
            homeViewModel.Sliders = sliders;
            homeViewModel.EntitiesLocalizedValues = test;
            return View(homeViewModel);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
    }
}