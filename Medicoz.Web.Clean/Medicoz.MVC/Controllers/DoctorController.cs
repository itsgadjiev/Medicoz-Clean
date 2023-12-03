using Medicoz.Application.Contracts.Localisation;
using Medicoz.Application.Contracts.Percistance;
using Medicoz.Domain;
using Medicoz.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Medicoz.MVC.Controllers
{
    [Route("medicoz/doctor")]
    public class DoctorController : Controller
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly ILocalizationService<Doctor> _localizationService;
        private readonly IDoctorScheduleRepository _doctorScheduleRepository;

        public DoctorController(IDoctorRepository doctorRepository, ILocalizationService<Doctor> localizationService, IDoctorScheduleRepository doctorScheduleRepository)
        {
            _doctorRepository = doctorRepository;
            _localizationService = localizationService;
            _doctorScheduleRepository = doctorScheduleRepository;
        }
        [Route("{doctorId}")]
        public async Task<IActionResult> Detail(int doctorId)
        {
            var doctor = await _doctorRepository.GetByIdAsync(doctorId);
            if (doctor == null) { return NotFound(); }

            DoctorDetailViewModel viewModel = new DoctorDetailViewModel
            {
                Description = _localizationService.GetLocalizedValue(doctorId, nameof(DoctorDetailViewModel.Description)),
                Education = _localizationService.GetLocalizedValue(doctorId, nameof(DoctorDetailViewModel.Education)),
                Experience = _localizationService.GetLocalizedValue(doctorId, nameof(DoctorDetailViewModel.Experience)),
                Title = _localizationService.GetLocalizedValue(doctorId, nameof(DoctorDetailViewModel.Title)),
                Phone = doctor.Phone,
                Email = doctor.Email,
                ImageURL = doctor.ImageURL,
                Name = doctor.Name,
                Surname = doctor.Surname,
                Fee=doctor.Fee,
                DoctorSchedules = await _doctorScheduleRepository.GetDoctorSchedulesByDoctorIdAsync(doctorId),
            };

            return View(viewModel);
        }
    }
}
