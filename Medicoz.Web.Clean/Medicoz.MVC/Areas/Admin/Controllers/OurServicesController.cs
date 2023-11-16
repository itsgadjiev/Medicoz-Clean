using Medicoz.Application.Contracts.Localisation;
using Medicoz.Application.Contracts.Percistance;
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

        public OurServicesController(ILocalizationService<OurService> localizationService, IOurServicesRepository ourServicesRepository)
        {
            _localizationService = localizationService;
            _ourServicesRepository = ourServicesRepository;
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
    }
}
