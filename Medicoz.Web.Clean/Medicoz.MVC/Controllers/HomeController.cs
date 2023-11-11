using Medicoz.Application.Contracts.Identity;
using Medicoz.Application.Contracts.Percistance;
using Medicoz.Domain;
using Medicoz.MVC.ViewModels;
using Medicoz.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Medicoz.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly IDatabaseLocalisationRepository<Slider> _databaseLocalisationRepository;

        public HomeController(IUserService userService,
            IDatabaseLocalisationRepository<Slider> databaseLocalisationRepository)
        {
            _userService = userService;
            _databaseLocalisationRepository = databaseLocalisationRepository;
        }
        public async Task<IActionResult> Index()
        {
            var sliders = await _databaseLocalisationRepository.GetLocalizedEntities();
            HomeViewModel homeViewModel = new HomeViewModel();
            homeViewModel.Sliders = sliders;
            return View(homeViewModel);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
    }
}