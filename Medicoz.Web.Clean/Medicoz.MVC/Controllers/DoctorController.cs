using MediatR;
using Medicoz.Application.Contracts.Identity;
using Medicoz.Application.Contracts.Localisation;
using Medicoz.Application.Contracts.Percistance;
using Medicoz.Application.Exceptions;
using Medicoz.Application.Features.DoctorAppointment.Commands;
using Medicoz.Domain;
using Medicoz.MVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Medicoz.MVC.Controllers
{
    [Route("medicoz/doctor")]
    public class DoctorController : Controller
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly ILocalizationService<Doctor> _localizationService;
        private readonly IDoctorScheduleRepository _doctorScheduleRepository;
        private readonly IMediator _mediator;
        private readonly IUserService _userService;

        public DoctorController(IDoctorRepository doctorRepository, ILocalizationService<Doctor> localizationService, IDoctorScheduleRepository doctorScheduleRepository,IMediator mediator,IUserService userService)
        {
            _doctorRepository = doctorRepository;
            _localizationService = localizationService;
            _doctorScheduleRepository = doctorScheduleRepository;
            _mediator = mediator;
            _userService = userService;
        }

        [HttpPost("appointment/{doctorId}")]
        public async Task<IActionResult> MakeAnAppointment(int doctorId, MakeAnAppointmentCommand makeAnAppointmentCommand)
        {
            makeAnAppointmentCommand.DoctorId = doctorId;
            makeAnAppointmentCommand.PasentId = _userService.UserId;
            try
            {
                await _mediator.Send(makeAnAppointmentCommand);
            }
            catch (BadRequestException ex)
            {
                ModelState.AddModelError("",ex.Message);
                return RedirectToAction("Detail", "Doctor", new { doctorId = doctorId });
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet("detail/{doctorId}")]
        public async Task<IActionResult> Detail(int doctorId)
        {
            var doctor = await _doctorRepository.GetByIdAsync(doctorId);
            if (doctor == null) { return NotFound(); }

            DoctorDetailViewModel viewModel = new DoctorDetailViewModel
            {
                Id = doctor.Id,
                Description = _localizationService.GetLocalizedValue(doctorId, nameof(DoctorDetailViewModel.Description)),
                Education = _localizationService.GetLocalizedValue(doctorId, nameof(DoctorDetailViewModel.Education)),
                Experience = _localizationService.GetLocalizedValue(doctorId, nameof(DoctorDetailViewModel.Experience)),
                Title = _localizationService.GetLocalizedValue(doctorId, nameof(DoctorDetailViewModel.Title)),
                Phone = doctor.Phone,
                Email = doctor.Email,
                ImageURL = doctor.ImageURL,
                Name = doctor.Name,
                Surname = doctor.Surname,
                Fee = doctor.Fee,
                DoctorSchedules = await _doctorScheduleRepository.GetDoctorSchedulesByDoctorIdAsync(doctorId),
            };

            return View(viewModel);
        }
    }
}
